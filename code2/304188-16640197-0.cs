        using System;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        //Step a
        using OpenQA.Selenium;
        using OpenQA.Selenium.Support;
        using OpenQA.Selenium.Firefox;
        using NUnit.Framework;
        namespace NUnitSelenium
        {
    [TestFixture]
    public class UnitTest1
    {      
        [SetUp]
        public void SetupTest()
        {
        }
        [Test]
        public void Test_OpeningHomePage()
        {
            // Step b - Initiating webdriver
            IWebDriver driver = new FirefoxDriver();
            //Step c : Making driver to navigate
            driver.Navigate().GoToUrl("http://docs.seleniumhq.org/");
          
            //Step d 
            IWebElement myLink = driver.FindElement(By.LinkText("Download"));
            myLink.Click();
     
            //Step e
            driver.Quit();
            )
           }
    }
