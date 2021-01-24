    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    
    namespace MyProject
    {
        public class Browser : IDisposable
        {
            bool disposed = false;    
            IWebDriver Driver;
            public Browser()
            {
                //Chrome Driver copied on startup path                
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService(Application.StartupPath, "chromedriver.exe");
                
                //hide driver service command prompt window
                driverService.HideCommandPromptWindow = true;
                ChromeOptions options = new ChromeOptions();
                
                //hide browser if you need              
                //options.AddArgument("headless");
                //or this to hiding browser
                //options.AddArgument("--window-position=-32000,-32000");
                //On offer Dona bhatt for disable automated test notification
                options.AddExcludedArgument("enable-automation");
                //options.AddArgument("disable-infobars");
        
                Driver = new ChromeDriver(driverService, options);
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (disposed)
                    return;
    
                if (disposing)
                {
                    Driver.Close();
                    Driver.Quit();
                    Driver.Dispose();
    
                    DriverService.Dispose();
                }
    
                disposed = true;
            } 
            //this method for navigation
            public string Navigate(string url)
            {
                string page = string.Empty;
                try
                {
                    Driver.Navigate().GoToUrl(url);
                    page =Driver.PageSource;
                }
                catch
                {
    
                }
                return page;
            }
    
            //this method for wait to an element be visible by element ID
            private void WaitUntilLoad(string id, int timeOut)
            {
                WebDriverWait waitForElement = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
                try
                {
                    waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
                }
                catch (WebDriverTimeoutException e)
                {
                    
                }
            }
         } 
     }
