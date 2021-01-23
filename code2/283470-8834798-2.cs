    private void Synchronize()
    {			
        SqlConnection con = new SqlConnection("Database=DesktopNotifier;Server=192.168.1.100\\sql2008;User=common;Password=k25#ap;");
        con.Open();
        SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM CustomerData", con);
        DataSet ds = new DataSet();
        adap.Fill(ds, "CustomerData");
        DataTable dt = new DataTable();
        dt = ds.Tables["CustomerData"];
			
        foreach (DataRow dr in dt.Rows)
        {				 
            string File = dr["CustomerFile"].ToString();
            string desc = dr["Description"].ToString();
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=D:\\DesktopNotifier\\DesktopNotifier.accdb";
            OleDbConnection conn = new OleDbConnection(conString);
            conn.Open();
            string dbcommand = "insert into CustomerData (CustomerFile, Description) VALUES ('" + File + "', '" + desc + "')";
            OleDbCommand mscmd = new OleDbCommand(dbcommand, conn);
            mscmd.ExecuteNonQuery();				 
        }
    }
    private void Configuration_Load(object sender, EventArgs e)
    {
        LoadGridData();
        LoadSettings();						
    }
