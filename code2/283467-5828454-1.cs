    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/temp/") + "FileName.xlsx; Extended Properties=Excel 12.0;";
    DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            DbDataAdapter adapter = factory.CreateDataAdapter();
            DbCommand selectCommand = factory.CreateCommand();
            selectCommand.CommandText = "SELECT ColumnNames FROM [Sheet1$]";
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            selectCommand.Connection = connection;
            adapter.SelectCommand = selectCommand;
            DataTable dtbl = new DataTable();
            adapter.Fill(dtbl);
     // Then use SQL Bulk query to insert those data
            if (dtbl.Rows.Count > 0)
    {
     using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnection))
            {
                bulkCopy.ColumnMappings.Add("ColumnName", "ColumnName");
                bulkCopy.ColumnMappings.Add("ColumnName", "ColumnName");
            bulkCopy.DestinationTableName = "DBTableName";
            bulkCopy.WriteToServer(dtblNew);
        }
    }
