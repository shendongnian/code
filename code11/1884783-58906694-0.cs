using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
namespace DoclerQAtests
{
    [Binding]
    public class WebDriverSupport
    {
        private readonly IObjectContainer objectContainer;
        private ChromeDriver webdriver;
        public WebDriverSupport(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }
        [BeforeScenario]
        public void InitializeWebDriver()
        {
            this.webdriver = new ChromeDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(webdriver);
        }
    }
}
