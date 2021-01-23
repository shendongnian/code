    var _setting = ConfigurationManager.AppSettings["SettingName"];
    // If we didn't find setting, try to load it from current dll's config file
    if (string.IsNullOrEmpty(_setting))
    {
        var filename = Assembly.GetExecutingAssembly().Location;
        var configuration = ConfigurationManager.OpenExeConfiguration(filename);
        if (configuration != null)
            _setting = configuration.AppSettings.Settings["SettingName"].Value;
    }
