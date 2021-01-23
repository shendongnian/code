    using (var connection = new SQLiteConnection("Data Source=yourfile.db;Version=3;"))
    using (var command = connection.CreateCommand())
    {
      connection.Open();
      command.CommandText = "select name from from sqlite_master";
      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          Console.WriteLine(Convert.String(reader["name"]));
        }
      }
    }
