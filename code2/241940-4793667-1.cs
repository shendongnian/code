    try
    {
            OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + frmMain.strFilePath + "\\ConfigStructure.mdb");
            myConnection.Open();
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "CREATE TABLE <yourtable name>(<columns>)";
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
    }
    catch(OleDbException e)
    {  
        if(e.ErrorCode == 3010 || e.ErrorCode == 3012)
        // if error then table exist do processing as required
    }
