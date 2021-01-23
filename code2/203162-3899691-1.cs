    [TestFixture]
    public class SiteTests
    {
        private ISelenium selenium;
        [SetUp]
        public void Setup()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://www.theautomatedtester.co.uk");
            selenium.Start();
        }
    
        [TearDown]
        public void Teardown()
        {
            selenium.Stop();
        }
    
        [Test]
        public void ShouldLoadHomeThenGoToXpathTutorial()
        {
            Home home = new Home(selenium);
            SeleniumTutorials seleniumTutorials = home.ClickSelenium();
            SeleniumXPathTutorial seleniumXPathTutorial = seleniumTutorials.ClickXpathTutorial();
            Assert.True(seleniumXPathTutorial.
    					IsInputOnScreen(SeleniumXPathTutorial.FirstInput));
            Assert.True(seleniumXPathTutorial
    					.IsInputOnScreen(SeleniumXPathTutorial.SecondInput));
            Assert.True(seleniumXPathTutorial
    					.IsInputOnScreen(SeleniumXPathTutorial.Total));
        }
    }
