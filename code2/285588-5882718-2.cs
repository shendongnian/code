    try
    {
        string connString = ...
        string sql = ...
    
        using (DataTable dt = new DataTable()) // not DataSet if you a single database table
        {
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                conn.Open();
                da.Fill(table);
            }
            
            foreach (DataRow row in dt.Rows)
            {
                // do stuff
            }    
        }
    }
    catch (SqlException ex)
    {
        // do stuff
    }
