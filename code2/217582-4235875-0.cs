    using (var connection = new MySqlConnection("connection-string"))
    {
      using (var command = new MySqlCommand(query, connection))
      {
        connection.Open();
        
        command.Parameters.AddWithValue("?name", name);
        
        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            Console.WriteLine(reader[0]);
          }
        }
      }
    }
