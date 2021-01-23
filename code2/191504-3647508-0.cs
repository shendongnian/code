    Database database = DatabaseFactory.CreateDatabase("conn string");
    
    using(DbConnection conn = database.CreateConnection())
    {    
        if(conn is SqlConnection)
        {
            var sqlConn = conn as SqlConnection;
        }
    }
