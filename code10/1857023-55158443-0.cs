    public OracleConnection GetConnection(string conn)
    {
    	try
    	{
    		string connectionString = _configuration["ConnectionStrings:" + conn];
    		OracleConnection dbConn = new OracleConnection(connectionString);
    		return dbConn;
    	}
    	catch(Exception ex)
    	{
    		throw ex;
    	}
    }
