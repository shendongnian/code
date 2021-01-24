    [Binding]
    public class BaseScenarioHooks
    {
        protected IObjectContainer Container;
        public BaseScenarioHooks(IObjectContainer container)
        {
            Container = container;
        }
        [BeforeScenario(Order = 3)]
        public void SetupDrivers()
        {
            var webDriver = new WebDriver(browser, seleniumHub, url, Context.ScenarioInfo.Title,
                Context["UniqueTestName"].ToString(), FrameworkConfiguration.VideoRecording);
            Container.RegisterInstanceAs<WebDriver>(webDriver);
        }
    }
