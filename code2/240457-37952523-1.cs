    pblic static void Set(string key, string value)
    {
    	var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    	var entry = config.AppSettings.Settings[key];
    	if (entry == null)
    		config.AppSettings.Settings.Add(key, value);
    	else
    		config.AppSettings.Settings[key].Value = value;
    
    	config.Save(ConfigurationSaveMode.Modified);
    }
