    Database database = DatabaseFactory.CreateDatabase("conn string");
    
    using(DbConnection connection = database.CreateConnection())
    {    
        if(connection is SqlConnection sqlConnection)
        {
            // do something with sqlConnection
        }
        else
        {
           throw new InvalidOperationException("Connection is not to a SQL Database");
        }
    }
