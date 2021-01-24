    public sealed class LazyWebDriver : IWebDriver
    {
        private readonly Lazy<IWebDriver> driver;
        public string Title => driver.Value.Title;
        // Other properties defined in IWebDriver just pass through to driver.Value.Property
        public LazyWebDriver(Func<IWebDriver> driverFactory)
        {
            driver = new Lazy<IWebDriver>(driverFactory);
        }
        public IWebElement FindElement(By by)
        {
            return driver.Value.FindElement(by);
        }
        public void Close()
        {
            driver.Value.Close();
        }
        // other methods defined in IWebDriver just pass through to driver.Value.Method(...)
    }
