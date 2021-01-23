    using (SqlConnection con = new SqlConnection(ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("Command", con))
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
