    using (var conn = new OracleConnection("Some connection string"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT id FROM foo";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
            }
        }
    }
