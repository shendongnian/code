    using (SqlConnection conn = new SqlConnection("connection string goes here"))
    using (SqlCommand comm = new SqlCommand("tesproc", conn))
    {
        comm.CommandType = CommandType.StoredProcedure;
        comm.Parameters.AddWithValue("@a", 0.1);
        // etc
    
        conn.Open();
    
        using (SqlDataReader reader = comm.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                // etc
            }
        }
    }
