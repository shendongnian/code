    using (var bulkCopy = new SqlBulkCopy(sqlConnection))
    {
        bulkCopy.DestinationTableName = dataTable.TableName;
        bulkCopy.WriteToServer(dataTable);
    }
