    using (var reader = fetchCommand.ExecuteReader())
    using (var bulkCopy = new SqlBulkCopy(myOtherDatabaseConnection))
    {
      bulkCopy.DestinationTableName = "...";
      bulkCopy.ColumnMappings = ...
      bulkCopy.WriteToServer(reader);
    }
