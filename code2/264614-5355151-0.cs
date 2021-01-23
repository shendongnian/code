    public void CreateTable(List<string> columnNames, string tableName)
    {
        Database database = DatabaseFactory.CreateDatabase("ConnectionTest");
        string connectionString = database.ConnectionString;
    
        //...
        newTable.Create();
    }
