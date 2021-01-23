    public IEnumerable<int> GetIds()
    {
        using (var connection = new SqlConnection(connectionString))
        using (var cmd = connection.CreateCommand())
        {
            connection.Open();
            cmd.CommandText = "select CategoryID from Categories";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader.GetInt32(reader.GetOrdinal("CategoryID"));
                }
            }
        }
    }
