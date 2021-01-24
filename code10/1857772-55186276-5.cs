    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
    {
        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
        {
            UseHeaderRow = true,
                    
            FilterColumn = (columnReader, columnIndex) =>
            {
                string header = columnReader.GetString(columnIndex);
                return (header == "LOCATION" || 
                        header == "PARENT" || 
                        header == "DESCRIPTION"
                       );                        
            }           
        }
    });
