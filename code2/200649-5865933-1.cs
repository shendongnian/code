    var oConn = new System.Data.Odbc.OdbcConnection();
    oConn.ConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + dbPath;
    oConn.Open();
    var oCmd = oConn.CreateCommand();
    oCmd.CommandText = @"SELECT name FROM " + dbPath + "TABLE.DBF";
    var reader = oCmd.ExecuteReader();
    reader.Read(); 
    byte[] A = Encoding.GetEncoding(Encoding.Default.CodePage).GetBytes(reader.GetString(0));
    string p = Encoding.Unicode.GetString((Encoding.Convert(Encoding.GetEncoding(850), Encoding.Unicode, A)));
