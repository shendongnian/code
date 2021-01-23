    IWebDriver WebDriver = null;
     
    try
    {
      System.Uri uri = new System.Uri("http://localhost:7055/hub");
      WebDriver = new RemoteWebDriver(uri, DesiredCapabilities.Firefox());
      Console.WriteLine("Executed on remote driver");
    }
    catch (Exception)
    {
      WebDriver = new FirefoxDriver();
      Console.WriteLine("Executed on New FireFox driver");
    }
    
    
