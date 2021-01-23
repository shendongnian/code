        string cnStr = @"Data Source=TEST;Initial Catalog=Suite;Persist Security Info=True;User ID=app;Password=Immmmmm";
        using (SqlConnection cn = new SqlConnection(cnStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM Date", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            Console.WriteLine(ds.Tables[0].Rows.Count);
            Console.WriteLine(cn.State);
        
        } // Closes on dispose here.
        
