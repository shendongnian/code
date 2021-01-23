    public static class Extension
    {
        public static bool HasConnectionString(this ConnectionStringSettingsCollection value, string key)
	{
	    try
		{
		    return value[key].ConnectionString.Length > 0;
		}catch 
		{
		    return false;
		}
	}
    }
