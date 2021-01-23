    System.Data.OleDb.OleDbConnection MyConnection;
    System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
    string sql = null;
    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\Example.xls';Extended Properties=Excel 8.0;");
    MyConnection.Open();
    myCommand.Connection = MyConnection;
