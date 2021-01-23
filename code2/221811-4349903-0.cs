    using (var csvReader = new CsvReader(@"D:\Data\Mock\mock_data.csv"))
    {
        while (csvReader.HasMoreRecords)
        {
            var record = csvReader.ReadDataRecord();
    
            if (record[0].StartsWith("#"))
            {
                if (csvReader.RecordCount > 0)
                {
                    EndBatch();
                }
                BeginBatch();
            }
            else
            {
                ProcessRecord(record);
            }
        }
    }
    
    private void BeginBatch()
    {
        Console.WriteLine("Beginning batch");
    }
    
    private void EndBatch()
    {
        Console.WriteLine("Ending batch");
    }
    
    private void ProcessRecord(DataRecord record)
    {
        Console.WriteLine("Processing record: {0}", record);
    }
