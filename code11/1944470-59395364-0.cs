    [Binding]
    internal sealed class WebHooks
    {
        private readonly IObjectContainer _objectContainer;
        public WebHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        [BeforeScenario("web")]
        public void BeforeWebScenario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("no-sandbox");
            //HACK: this fixes issue with not being able to find chromedriver.exe
            //https://stackoverflow.com/questions/47910244/selenium-cant-find-chromedriver-exe
            var webDriver = new ChromeDriver(".", options);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
        }
        [AfterScenario("web")]
        public void AfterWebScenario()
        {
            var webDriver = _objectContainer.Resolve<IWebDriver>();
            if (webDriver == null) return;
            webDriver.Close();
            webDriver.Dispose();
        }
    }
