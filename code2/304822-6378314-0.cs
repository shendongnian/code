    public static T GetConfigEnumValue<T>(NameValueCollection config, string configKey, T defaultValue)
    {
    	if (config == null)
    	{
    		return defaultValue;
    	}
    
    	if (config[configKey] == null)
    	{
    		return defaultValue;
    	}
    
    	T result = defaultValue;
    	string configValue = config[configKey].Trim();
    
    	if (string.IsNullOrEmpty(configValue))
    	{
    		return defaultValue;
    	}
    
    	try
    	{
    		result = (T)Enum.Parse(typeof(T), configValue, true);
    	}
    	catch
    	{
    		result = defaultValue;
    	}
    
    	return result;
    }
