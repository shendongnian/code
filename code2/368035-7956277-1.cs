    private string GetADOConnectionString()
    {
        var db = new DataBaseEntities();
        
    	EntityConnection ec = (EntityConnection)db.Connection;
        return ec.StoreConnection.ConnectionString;
    }
