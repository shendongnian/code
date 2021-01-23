    using (SqlConnection conn = new SqlConnection(
       ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString))
    {
        conn.Open();
        // do stuff
    }
