    private static OdbcConnection _Connection;
    public static OdbcConnection GetOdbcConnection() { 
    	string connectionString = 
    		ConfigurationManager.AppSettings["ConnectionString"].ToString(); 
    	_Connection = new OdbcConnection(connectionString);
    	return _Connection;
    }
