    [Binding]
    public sealed class SeleniumHooks
    {
        private readonly IObjectContainer objectContainer;
        public SeleniumHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }
        [BeforeFeature]
        public void RegisterWebDriver()
        {
            objectContainer.RegisterInstanceAs<IWebDriver>(new LazyWebDriver(CreateWebDriver));
        }
        private IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }
        [AfterFeature]
        public void DestroyWebDriver()
        {
            objectContainer.Resolve<IWebDriver>()?.Close();
        }
    }
