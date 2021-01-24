    public class UiTest : IDisposable
    {
        private IWebDriver driver = null;
    
        protected IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                }
                return _driver;
            }
        }
    
        public void Dispose()
        {
            driver?.Dispose();
        }
    }
