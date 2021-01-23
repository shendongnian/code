    public static DataTable GetBySQLStatement(string SQLText)
    {
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
        string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Pets.MDB";
        System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection();
        Conn.ConnectionString = ConnectionString;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = Conn;
        cmd.CommandText = SQLText;
 
        DataSet ds;
        System.Data.OleDb.OleDbDataAdapter da;
        DataTable Table = null;
        Conn.Open();
        da = new System.Data.OleDb.OleDbDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables.Count > 0)
            Table = ds.Tables[0];
        Conn.Close();
        return Table;
    }
