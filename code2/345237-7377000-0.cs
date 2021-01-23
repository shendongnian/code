     System.Data.Odbc.OdbcDataAdapter Odbcda;
    
    //CSV File
    strConnString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + SourceLocation + ";Extensions=asc,csv,tab,txt;Persist Security Info=False";
    
    sqlSelect = "select * from [" + filename + "]";
    
    System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(strConnString.Trim());
    
    conn.Open();
    Odbcda = new System.Data.Odbc.OdbcDataAdapter(sqlSelect, conn);
    Odbcda.Fill(ds, DataTable);
    conn.Close();
