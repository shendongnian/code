    //string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;";
    string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;";
    
    ConnectionString = string.Format(ConnectionString, @"FullPathToExcelFile");
    
    OleDbConnection conn = new OleDbConnection(ConnectionString);
    conn.Open();
     
    OleDbCommand cmdSelect = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
    OleDbDataAdapter oleDBAdapter = new OleDbDataAdapter();
    oleDBAdapter.SelectCommand = cmdSelect;
     
    DataSet myDataset = new DataSet();
    oleDBAdapter.Fill(myDataset);
    conn.Close(); 
    
    // Do whatever with data in myDataset including export to csv...
