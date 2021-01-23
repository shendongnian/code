    Configuration config = null;
    string exeConfigPath = this.GetType().Assembly.Location;
    try
    {
    	config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
    }
    catch (Exception ex)
    {
    	//handle errror here.. means DLL has no sattelite configuration file.
    }
    
    if (config != null)
    {
    	string myValue = GetAppSetting(config, "myKey");
    	...
    }
