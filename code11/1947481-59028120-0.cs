    private void Run()
    {
    	string query = "SELECT * FROM dbo.[Anrufthema]";
    	SqlConnection conn = new SqlConnection("MyConnectionString");
    	conn.Open();
    	
    	SqlDataAdapter SDA = new SqlDataAdapter(query, conn);
    	DataSet ds1 = new DataSet();
    	DataTable dt = new DataTable();
    	SDA.Fill(dt);
    	dt.Rows[0]["Anrufthema"] = "98"; //Before it was 10
    	dt.Rows[1]["Anrufthema"] = "99"; //Before it was 11
    	ds1.Tables.Add(dt);
    	
    	conn.Close();
    }
