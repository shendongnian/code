    public static void BulkCopy(string inputFilePath, string tableName)
        {
    
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read);
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                using (var bulkCopy = new SqlBulkCopy(ConnectionString))
                {
    
                    bulkCopy.EnableStreaming = true;
                    bulkCopy.DestinationTableName = tableName;
                    reader.Read();
                    var cols = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetValue(i)).ToArray();
                    foreach (var col in cols)
                    {
                         if (cols[i].ToString() == "Column 1")
				         {
				              bulkCopy.ColumnMappings.Add(i, "Column 1");
			     	     }
     				     if (cols[i].ToString() == "Column 2")
	     			     {
		     			      bulkCopy.ColumnMappings.Add(i, "Column 2");
			     	     }
				         if (cols[i].ToString() == "Column 3")
          				 {
	          			      bulkCopy.ColumnMappings.Add(i, "Column 3");
		          		 }
    
                        //continued for column mappings...
    
                    }
    
                    bulkCopy.WriteToServer(reader);
                }
                Console.WriteLine("Copy data to database done (DataReader).");
            }
        }
