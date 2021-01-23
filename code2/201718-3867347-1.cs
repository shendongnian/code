    public IEnumerable<Player> GetPlayers()
    {
        string connectionString = ConfigurationManager.AppSettings["AllRttpDBConnectionString"];
        using (var conn = new MySqlConnection(connectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT Name, Number FROM test WHERE ServiceName LIKE 'T%';";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Player 
                    {
                        Name = reader.GetString(0),
                        Number = reader.GetInt32(1)
                    };
                }
            }
        }
    }
