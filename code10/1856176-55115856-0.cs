      using (var sqlBulk = new SqlBulkCopy(_connectionString))
    {
        sqlBulk.NotifyAfter = 1000;
        sqlBulk.SqlRowsCopied += (sender, eventArgs) => Console.WriteLine("Wrote " + eventArgs.RowsCopied + " records.");
        sqlBulk.DestinationTableName = "Employees";
        sqlBulk.WriteToServer(dt);
    }
