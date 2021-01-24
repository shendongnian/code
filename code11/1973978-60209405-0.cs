    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
    {
        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
        {
            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
            {
                UseHeaderRow = true
            }
        });
                
        DataTable dataTable = result.Tables[0];
        foreach(var row in dataTable.Rows)
        {
            //Your logic
        }
    }
