    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    //add this name space to access WebDriverWait
    using OpenQA.Selenium.Support.UI;
    namespace MyTest
    {
    [TestClass]
    public class MyTest
    {
        public static IWebDriver Driver = null;
        // Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            try
            {
                string path = Path.GetFullPath("");         //Copy the chrome driver to the debug folder in the bin or set path accordingly
                Driver = new ChromeDriver(path);
            }
            catch (Exception ex)
            { string error = ex.Message; }
        }
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyCleanup()
        {
            Driver.Quit();
        }
        [TestMethod]
        public void MyTestMethod()
        {
            try
            {
                string url = "http://www.google.com";
                Driver.Navigate().GoToUrl(url);
                IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30.00));                    // Waiter in Selenium
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(@"//*[@id='lst - ib']")));
                var txtBox = Driver.FindElement(By.XPath(@"//*[@id='lst - ib']"));
                txtBox.SendKeys("Google Office");
                var btnSearch = Driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[3]/center/input[1]"));
                btnSearch.Click();
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
    }
