    leDbConnection connection = 
    new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventar.accdb");
    DataSet1 DS = new DataSet1();
    connection.Open();
    OleDbDataAdapter DBAdapter = new OleDbDataAdapter(
    @"SELECT tbl_Computer.*,  tbl_Besitzer.*
      FROM tbl_Computer 
      INNER JOIN tbl_Besitzer ON tbl_Computer.FK_Benutzer = tbl_Besitzer.ID 
      WHERE (((tbl_Besitzer.Vorname)='ma'));", 
    connection);
