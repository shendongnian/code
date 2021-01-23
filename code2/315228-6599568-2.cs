    public static class Extension
    {
        public static bool HasConnectionString(this ConnectionStrings value, string key)
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
