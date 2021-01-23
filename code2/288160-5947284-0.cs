    using (SqlConnection conn = new SqlConnection(...))
    using (SqlCommand command = conn.CreateCommand())
    {
        command.CommandText = "...";
        conn.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            // do the sutff
        }
    }
