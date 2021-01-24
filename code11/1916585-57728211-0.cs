    here is an example of bulk insert:
    string BulkSaveConnection = //connection;
    using (var connection = new SqlConnection(BulkSaveConnection))
    {
        SqlTransaction transaction = null;
        connection.Open();
        try
        {
            transaction = connection.BeginTransaction();
            using (var sqlBulkCopy = new SqlBulkCopy(connection, sqlBulkCopyOptions.TableLock, transaction))
            {
                sqlBulkCopy.DestinationTableName = "[ServerName].[TableName]";
                sqlBulkCopy.ColumnMappings.Add("sourceColumnName1", "DestinationColumnName");
                sqlBulkCopy.ColumnMappings.Add("sourceColumnName2", "DestinationColumnName");
                //
                //
                //
                sqlBulkCopy.WriteToServer(dataTable);
           }
           transaction.Commit();
       }
        catch (Exception ex)
        {
           Console.WriteLine(ex.ToString());
           transaction.Rollback();
        }
   }
