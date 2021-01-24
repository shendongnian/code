    string strConnect = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=D:\Temp\MyDB.accdb";
    
    DataTable dt = new DataTable();
    using (OleDbConnection con = new OleDbConnection(strConnect))
        {
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM MyTable", con);
        con.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        da.Fill(dt);
        }
