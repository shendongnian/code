    private string GetADOConnectionString()
    {
        var db = new DataBaseEntities();
        
    	EntityConnection ec = (EntityConnection)db.Connection;
        SqlConnection sc = (SqlConnection)ec.StoreConnection;
        
    	return sc.ConnectionString;
    }
