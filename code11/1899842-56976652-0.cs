    using (var bulk = new SqlBulkCopy(con)
    {
        //bulk mapping is a SqlBulkCopyColumnMapping[] and is not necessaraly needed if the DataTable matches your destination table exactly
        foreach (var i in bulkMapping)
        {
            bulk.ColumnMappings.Add(i);
        }
        bulk.DestinationTableName = "MyTable";
        bulk.BulkCopyTimeout = 600;
        bulk.BatchSize = 5000;
        bulk.WriteToServer(someDataTable);
    }
