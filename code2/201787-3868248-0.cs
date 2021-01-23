    NameValueCollection settings = System.Configuration.ConfigurationManager.AppSettings;
    
    foreach (string key in settings.AllKeys)
    {
       string value = settings[key];
    }
