    System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
    oConn.ConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + dbPath;
    oConn.Open();
    System.Data.Odbc.OdbcCommand oCmd = oConn.CreateCommand();
    oCmd.CommandText = @"SELECT name FROM " + dbPath + "TABLE.DBF";
    System.Data.Odbc.OdbcDataReader reader = oCmd.ExecuteReader();
    reader.Read(); 
    byte[] A = Encoding.GetEncoding(Encoding.Default.CodePage).GetBytes(reader.GetString(0));
    string p = Encoding.Unicode.GetString((Encoding.Convert(Encoding.GetEncoding(850), Encoding.Unicode, A)));
