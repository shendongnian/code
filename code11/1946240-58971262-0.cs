    using (SqlBulkCopy sqlBulk = new SqlBulkCopy(GetConnectionString(), SqlBulkCopyOptions.CheckConstraints))
    {
        sqlBulk.DestinationTableName = tableName;
        sqlBulk.WriteToServer(newDt);
    }
