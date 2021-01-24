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
                
                //hide browser                
                options.AddArgument("headless");
                //or this to hiding browser
                //options.AddArgument("--window-position=-32000,-32000");
    
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
        } 
    }
        
