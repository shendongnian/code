    private static void ReadOrderData(string connectionString,
      string query, Action<SqlDataReader> action)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        using (SqlCommand command =
            new SqlCommand(query, connection)) {
        connection.Open();
    
        using (SqlDataReader reader = command.ExecuteReader()) {
    
        // Call Read before accessing data.
        while (reader.Read())
        {
            action(reader);
        }
    
        // No need to call Close when done reading.
        // reader.Close();
        } // End SqlDataReader
       } // End SqlCommand
      }
    }
