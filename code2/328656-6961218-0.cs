    private static void ReadOrderData(string connectionString,
      string query, Action<SqlDataReader> action)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command =
            new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        // Call Read before accessing data.
        while (reader.Read())
        {
            action(reader);
        }
        // Call Close when done reading.
        reader.Close();
      }
    }
