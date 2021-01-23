    using (var conn = new MySqlConnection("Some connection string"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT foo FROM bar";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // process the results
            } 
        }
    }
