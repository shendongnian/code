    using (SqlConnection con = new SqlConnection("connection string"))
    {
        con.Open();
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = "select * from table";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                ...
            }
        }
    }
