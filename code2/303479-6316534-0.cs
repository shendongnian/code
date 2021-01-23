    public static class SqlCeExtentions
    {
      public static bool TableExists(this SqlCeConnection connection, string tableName)
      {
        if (tableName == null) throw new ArgumentNullException("tableName");
        if (string.IsNullOrWhiteSpace(tableName)) throw new ArgumentException("Invalid table name");
        if (connection == null) throw new ArgumentNullException("connection");
        if (connection.State != ConnectionState.Open)
        {
          throw new InvalidOperationException("TableExists requires an open and available Connection. The connection's current state is " + connection.State);
        }
      
        using (SqlCeCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.Text;
          command.CommandText = "SELECT 1 FROM Information_Schema.Tables WHERE TABLE_NAME = @tableName";
          command.Parameters.AddWithValue("tableName", tableName);
          object result = command.ExecuteScalar();
          return result != null;
        }
      }
    }
