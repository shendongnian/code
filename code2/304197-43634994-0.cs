    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using SeleniumAutomationFramework.CommonMethods;
    using System.Text;
    
    [TestClass]
        public class SampleInCSharp
        {
    
            public static IWebDriver driver = Browser.CreateWebDriver(BrowserType.chrome);
    
            [TestMethod]
            public void SampleMethodCSharp()
            {
                
    
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                driver.Url = "http://www.store.demoqa.com";
                driver.Manage().Window.Maximize();
    
                driver.FindElement(By.XPath(".//*[@id='account']/a")).Click();
                driver.FindElement(By.Id("log")).SendKeys("kalyan");
                driver.FindElement(By.Id("pwd")).SendKeys("kalyan");
                driver.FindElement(By.Id("login")).Click();
    
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.LinkText("Log out")));
                
                Actions builder = new Actions(driver);
                builder.MoveToElement(driver.FindElement(By.XPath(".//*[@id='menu-item-33']/a"))).Build().Perform();
                driver.FindElement(By.XPath(".//*[@id='menu-item-37']/a")).Click();
                driver.FindElement(By.ClassName("wpsc_buy_button")).Click();
                driver.FindElement(By.XPath(".//*[@id='fancy_notification_content']/a[1]")).Click();
                driver.FindElement(By.Name("quantity")).Clear();
                driver.FindElement(By.Name("quantity")).SendKeys("10");
                driver.FindElement(By.XPath("//*[@id='checkout_page_container']/div[1]/a/span")).Click();
                driver.FindElement(By.ClassName("account_icon")).Click();
                driver.FindElement(By.LinkText("Log out")).Click();
                driver.Close();
            }
    }
