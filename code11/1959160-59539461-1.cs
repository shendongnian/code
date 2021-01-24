     public class DriverContext {
        
          public WebDriver Driver { get; set; }
          public DriverContext ()
            {
                
            }
        public void StartDriver()
        {
           Driver=new ChromeDriver();
        }
    ....
    }
