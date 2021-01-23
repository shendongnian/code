    string sql = "INSERT INTO games (col1,col2) VALUES (1,2);");
    string connectionString = "some connection string";
    using (TransactionScope scope = new TransactionScope)
    {
        int rowsAffected = MySqlHelper.ExecuteNonQuery(connectionString, sql);    
        object id = MySqlHelper.ExecuteScalar(connectionString, "SELECT LAST_INSERT_ID();");
        scope.Complete();
    }
