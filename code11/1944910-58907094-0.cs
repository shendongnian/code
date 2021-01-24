 public static IWebDriver Driver { get; set; }
2 -  pass the driver id  to BasePage.Driver 
     public void Initialize()
        {
            this.webdriver = new ChromeDriver();
            BasePage.Driver = webdriver;
            objectContainer.RegisterInstanceAs<IWebDriver>(this.webdriver);
        }
