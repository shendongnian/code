    MyDataSet myDS = new MyDataset();
    //Some query commands using OleDB to get data from Excel
    OleDbDataAdapter myAdapter = new OleDbDataAdapter(<OleDbCommand>);
    DataTableMapping tableMap = myAdapter.TableMappings.Add("Table", myDS.FirstTable.TableName);
    tableMap.ColumnMappings.Add("ExcelCol1", myDS.FirstTable.Column1.ColumnName);
    tableMap.ColumnMappings.Add("ExcelCol2", myDS.FirstTable.Column2.ColumnName);
    myAdapter.Fill(myDS);
