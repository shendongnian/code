    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
    
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
        {
            bulkCopy.DestinationTableName = "table";
    
            bulkCopy.WriteToServer(Records);
        }
    }
