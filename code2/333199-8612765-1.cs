    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
        
    namespace SeleniumTests
    {
        [TestFixture]
        public class Test
        {
           private IWebDriver driver;
        		
           [SetUp]
           public void Setup()
           {
              var options = new InternetExplorerOptions();
              options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
              driver = new InternetExplorerDriver(options);
           }
        }
    }
