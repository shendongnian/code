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
    catch(Exception e)
    {  
        // if error then table exist do processing as required
    }
