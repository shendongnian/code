     public class Browser
     {
        static IWebDriver _Driver;
        static WebDriverWait _wait;
      public static void StartWebDriver()
      {
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService(Path.Combine(GetBasePath, @"bin\Debug\"));
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-extensions");
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    options.AddExcludedArgument("enable-automation");
                    _Driver = new ChromeDriver(service, options);
                    _wait = new WebDriverWait(_Driver, TimeSpan.FromSeconds(10));
      }
    
        public static string GetBasePath
        {
            get
            {
                var basePath =
                    System.IO.Path.GetDirectoryName((System.Reflection.Assembly.GetExecutingAssembly().Location));
                basePath = basePath.Substring(0, basePath.Length - 10);
                return basePath;
            }
        }
      }
