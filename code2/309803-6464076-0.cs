    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString))
    {
        con.Open();            
        //
        // Some code
        //
    }
