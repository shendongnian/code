	public class CustomChromeOptionsSeleniumWebDriver : SeleniumWebDriver
    {
        public CustomChromeOptionsSeleniumWebDriver(Browser browser)
            : base(CustomProfile(), browser) {}
        private static RemoteWebDriver CustomChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("start-maximized");
            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("useAutomationExtension", false);
            return new ChromeDriver(chromeOptions);
        }
    }
    [SetUp]
    public void SetUp()
    {		
        var configuration = new SessionConfiguration
        {
            Timeout = TimeSpan.FromMilliseconds(2000),
            Driver = typeof(CustomChromeOptionsSeleniumWebDriver),
            Browser = Browser.Chrome,
        };
        browser = new BrowserSession(configuration);
    }
