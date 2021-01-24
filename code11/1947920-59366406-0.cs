    using Deedle;
    using ExcelDataReader;
    
    // your code is omit
    ...
    // below is the key code
                Frame<int, string> mydf;
    
                using (var stream = File.Open(myFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            UseColumnDataType = true,
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true,  // to use the first row as header
                            }
                        });
                        DataTableReader rd = result.Tables[0].CreateDataReader();  //just use the first sheet
                        mydf = Frame.ReadReader(rd);
                    }
                }
    
    // use mydf below
    ...
