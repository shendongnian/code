    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using System.Threading;
    
    namespace SeleniumTests 
    {
        [TestFixture(typeof(FirefoxDriver))]
        [TestFixture(typeof(InternetExplorerDriver))]
        public class TestWithMultipleBrowsers<TWebDriver> where TWebDriver : IWebDriver, new()
        {
            private IWebDriver driver;
    
            [SetUp]
            public void CreateDriver () {
                this.driver = new TWebDriver();
            }
    
            [Test]
            public void GoogleTest() {
                driver.Navigate().GoToUrl("http://www.google.com/");
                IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("Bread" + Keys.Enter);
                
                Thread.Sleep(2000);
    
                Assert.AreEqual("bread - Google Search", driver.Title);
                driver.Quit();
            }
        }
    }
