    using (var bulkcopy = new SqlBulkCopy("connection string")) {
        bulkcopy.DestinationTableName = "main";
        bulkcopy.WriteToServer(jsonTable);
        bulkcopy.DestinationTableName = "items";
		bulkcopy.WriteToServer(items);
        bulkcopy.DestinationTableName = "payments";
		bulkcopy.WriteToServer(payments);
    }	
