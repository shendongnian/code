    var connectionString = 
        string.Format("Server=.\\SQLEXPRESS;Database={0};Trusted_Connection=true", dbName);
    using (var sqlConnection = new SqlConnection(connectionString))
    {
        sqlConnection.Open();
        DataTable tables = sqlConnection.GetSchema("Tables");
        foreach (DataRow tablesRow in tables.Rows)
        {
            string tableName = tablesRow["table_name"].ToString();
            Console.WriteLine(tableName);
            var indexCols = sqlConnection.GetSchema("IndexColumns",
                new string[] {dbName, null, tableName, "PK_" + tableName, null});
            foreach (DataRow indexColsRow in indexCols.Rows)
                Console.WriteLine("  PK: {0}", indexColsRow["column_name"]);
        }
    }
