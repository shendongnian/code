    public static string ConnectionString
    {
    	get {
    		if (ConfigurationManager.AppSettings["DevelopmentEnvironment"] == "true")
    			return ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
    		else
    			return ConfigurationManager.ConnectionStrings["ExternalDb"].ConnectionString;
    	}
    }
    
    public ApplicationDbContext() : base(ConnectionString)
    {
    }
