    public static void BulkCopy(string inputFilePath, string tableName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open(inputFilePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader;
            if (inputFilePath.EndsWith(".xls"))
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            else if (inputFilePath.EndsWith(".xlsx"))
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            else
                throw new Exception("The file to be processed is not an Excel file");
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            var dataSet = reader.AsDataSet(conf);
            // Now you can get data from each sheet by its index or its "name"
            var dataTable = dataSet.Tables[0];
            using (var bulkCopy = new SqlBulkCopy(ConnectionString))
                {
                    bulkCopy.EnableStreaming = true;
                    bulkCopy.DestinationTableName = tableName;
                    reader.Read();
                    var cols = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetValue(i)).ToArray();
                    foreach (var col in cols)
                    {
                        var column =col.ToString();
                        if (column.Trim() == "Column 1")
                        {
                            bulkCopy.ColumnMappings.Add(column, "Column1");
                        }
                        if (column.Trim() == "Column 2")
                        {
                            bulkCopy.ColumnMappings.Add(column, "Column2");
                        }
                        if (column.Trim() == "Column 3")
                        {
                            bulkCopy.ColumnMappings.Add(column, "Column3");
                        }
                        //continued for column mappings...
                    }
                    bulkCopy.WriteToServer(dataTable);
                }
                Console.WriteLine("Copy data to database done (DataReader).");           
        }
