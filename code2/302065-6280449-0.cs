    public static class MyConfig
    {
    	/// documentation of config entry
    	public static string Browser
    	{
    	  get { return Read("Browser", "some default value"); }
    	}
    
    	/// documentation of config entry
    	public static int Port
    	{
    	  get { return int.Parse(Read("Browser", "80")); }
    	}
    
    	public static string Read(string entry, string defaultValue)
    	{
    		var entry = ConfigurationManager.AppSettings[entry];
    		return string.IsNullOrEmpty(entry) ? defaultValue : entry;
    	}
    }
