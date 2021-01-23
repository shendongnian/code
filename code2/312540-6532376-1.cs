    OleDbConnection connection = new OleDbConnection(
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventar.accdb");
    DataSet1 DS = new DataSet1();
    connection.Open();
    
    string query = 
        @"SELECT tbl_Computer.*,  tbl_Besitzer.*
        FROM tbl_Computer 
        INNER JOIN tbl_Besitzer ON tbl_Computer.FK_Benutzer = tbl_Besitzer.ID 
        WHERE (((tbl_Besitzer.Vorname)='ma'))";
    OleDbDataAdapter DBAdapter = new OleDbDataAdapter();
    DBAdapter.SelectCommand = new OleDbCommand(query, connection); 
    DBAdapter.Fill(DS);
