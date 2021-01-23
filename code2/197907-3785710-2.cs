    DataTable table = new DataTable();
    using (var adapter = new SqlDataAdapter(sourceCommand))
    {
        adapter.Fill(table);
    }
    using (SqlBulkCopy bulk = new SqlBulkCopy(targetConnection, SqlBulkCopyOptions.KeepIdentity, null) { DestinationTableName = tableName })
    {
        foreach (string columnName in GetMapping(stringSource, stringTarget, tableName))
        {
            bulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping(columnName, columnName));
        }
    
        targetConnection.Open();
        bulk.WriteToServer(table);
    }
    private static IEnumerable<string> GetMapping(string stringSource, string stringTarget, string tableName)
    {
        return Enumerable.Intersect(
            GetSchema(stringSource, tableName),
            GetSchema(stringTarget, tableName),
            StringComparer.Ordinal); // or StringComparer.OrdinalIgnoreCase
    }
    
    private static IEnumerable<string> GetSchema(string connectionString, string tableName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = "sp_Columns";
            command.CommandType = CommandType.StoredProcedure;
    
            command.Parameters.Add("@table_name", SqlDbType.NVarChar, 384).Value = tableName;
    
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return (string)reader["column_name"];
                }
            }
        }
    }
