      [BeforeFeature(), Scope(Feature = "SearchTests")]
      public static void Startup()
      {
          _driver = new ChromeDriver();
      }
    
      [AfterFeature()]
      public static void ShutDown()
      {
          _driver?.Close();
      }
