    string xmlFilePath = @"D:\test.xml";
    
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Col1");
    dataTable.Columns.Add("Col2");
    dataTable.Columns.Add("Col3");
    
    dataTable.Rows.Add(1, "abc", "zyx");
    dataTable.Rows.Add(2, "cde", "mno");
    dataTable.Rows.Add(3, "def", "fru");
    
    WriteDataTableToXml(dataTable, xmlFilePath);
