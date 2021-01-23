    void Save()
    { 
        OleDbConnection con=new OleDbConnection("Put your connect string here");
        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TestQuery", con);
        OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
        DataTable tbl = dsB.Tables[0];
        da.Update(tbl);
        tbl.AcceptChanges();
    }
