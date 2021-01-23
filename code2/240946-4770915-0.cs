    DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SQLite");
    using (DbConnection connection = factory.CreateConnection())
    {
        connection.ConnectionString = @"Data Source=D:\tmp\test.db";
        connection.Open();
        DataTable tables = connection.GetSchema("Tables");
        DataTable columns = connection.GetSchema("Columns");
        tables.Dump();
        columns.Dump();
    }
