    string connectionString= ServerName + DatabaseName + SecurityType;
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection)) {
        connection.Open();
        bulkCopy.DestinationTableName = "TableName";
        try {
            bulkCopy.WriteToServer(dataTableName);
        } catch (Exception e) {
            Console.Write(e.Message);
        }
    }
