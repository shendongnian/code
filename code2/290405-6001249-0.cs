    using (DataSet ds = new DataSet())
    {
        using (SqlConnection conn = new SqlConnection(connstring))
        using (SqlDataAdapter ad = new SqlDataAdapter("", conn))
        {
            ad.Fill(ds);
        }
    
        // access ds;
    }
