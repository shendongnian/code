    using (SqlConnection connection = new SqlConnection(connString))
    {
        SqlBulkCopy bulkCopy = new SqlBulkCopy(
            connection, 
            SqlBulkCopyOptions.TableLock | 
            SqlBulkCopyOptions.FireTriggers | 
            SqlBulkCopyOptions.UseInternalTransaction,
            null
            );    
        bulkCopy.DestinationTableName = tableName;
        connection.Open();
        bulkCopy.WriteToServer(dataTable);
        connection.Close();
    }
