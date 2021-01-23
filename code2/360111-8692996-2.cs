    using (var connection = CreateDbConnection())
    {
        connection.Open();
        using (var copy = new OracleBulkCopy(connection))
        {
            copy.DestinationTableName = tableName;
            copy.BulkCopyTimeout = DefaultTimeoutInSeconds;
            copy.BatchSize = BatchSize;
            copy.Insert(entities);
        }
    }
