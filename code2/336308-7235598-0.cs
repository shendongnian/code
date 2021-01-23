      [ClassInitialize]
      public static void LaunchBroswer(TestContext context)
      {         
         Playback.Initialize(); 
         BrowserWindow browser = BrowserWindow.Launch(new System.Uri("about:blank"));
      }
