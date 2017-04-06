using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Threading;


namespace CodedUITestProject1
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.


            this.UIMap.Login();
        }
        [TestMethod]
        [Description("Test case 15373: 1131.1- Build List Manager (CMR001, CMR016, CMR010)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @".\XMLFile1.xml", "Login", DataAccessMethod.Sequential), DeploymentItem(@".\Input\XMLFile1.xml")]
        public void Login()
        {
            BrowserWindow apBrowserWindow =  BrowserWindow.Launch(new System.Uri(TestContext.DataRow["Site"].ToString()));


            HtmlEdit userName = new HtmlEdit(apBrowserWindow);
            userName.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "ctl00_ContentPlaceHolder1_ctl00_UserName");

            HtmlEdit password = new HtmlEdit(apBrowserWindow);
            password.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "ctl00_ContentPlaceHolder1_ctl00_Password");

            HtmlInputButton login = new HtmlInputButton(apBrowserWindow);
            login.SearchProperties.Add(HtmlInputButton.PropertyNames.Id, "ctl00_ContentPlaceHolder1_ctl00_SignOn");


            userName.Text = TestContext.DataRow["UserName"].ToString();
            Mouse.Click(password);
            password.Password = Playback.EncryptText(TestContext.DataRow["Password"].ToString());

            Assert.AreEqual("Sign On", login.DisplayText,"Text doesn't match");
            Mouse.Click(login);
        }








        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
