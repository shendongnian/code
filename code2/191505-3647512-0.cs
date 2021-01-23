    Database database = DatabaseFactory.CreateDatabase("connection string");
    using (var conn = database.CreateConnection())
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT id FROM foo";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // TODO: work with the results here
            }
        }
    }
