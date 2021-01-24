    public class UiTest : IDisposable
    {
        private IWebDriver driver = null;
    
        protected IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = new ChromeDriver(new ChromeOptions{Proxy = null});
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
