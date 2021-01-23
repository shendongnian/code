    string strConn = "Provider=Microsoft.Jet.OleDb.4.0;data source=C:\\Inetpub\\wwwroot\\CS\\HostData.xls;Extended Properties=Excel 8.0;";
    OleDbConnection objConn = new OleDbConnection(strConn);
    
    string strSQL = "SELECT * FROM [A1:B439]";
    OleDbCommand objCmd = new OleDbCommand(strSQL, objConn);
    
    objConn.Open();
    dgReadHosts.DataSource = objCmd.ExecuteReader();
    dgReadHosts.DataBind();
    objConn.Close();
