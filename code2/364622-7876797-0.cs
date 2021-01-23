    // Get the AppSettings section.        
    // This function uses the AppSettings property
    // to read the appSettings configuration 
    // section.
    public static void ReadAppSettings()
    {
        // Get the AppSettings section.
        NameValueCollection appSettings =
           ConfigurationManager.AppSettings;
        // Get the AppSettings section elements.
        for (int i = 0; i < appSettings.Count; i++)
        {
          Console.WriteLine("#{0} Key: {1} Value: {2}",
            i, appSettings.GetKey(i), appSettings[i]);
        }
    }
