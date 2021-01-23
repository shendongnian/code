    public IEnumerable<Player> GetPlayers()
    {
        string connectionString = ConfigurationManager.AppSettings["AllRttpDBConnectionString"];
        using (var connection = new MySqlConnection(connectionString))
        using (var cmd = connection.CreateCommand())
        {
            connection.Open();
            cmd.CommandText = "SELECT Name, Number FROM test WHERE ServiceName LIKE 'T%';";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Player 
                    {
                        Name = reader.ReadString(0),
                        Number = reader.ReadInt32(1)
                    };
                }
            }
        }
    }
