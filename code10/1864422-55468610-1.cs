    public static IEnumerable<Object[]> DbQueryToArray(string sql) {
      if (null == sql)
        throw new ArgumentNullException(nameof(sql));
      string SqlCString = "connString";
      using (SqlConnection connection = new SqlConnection(SqlCString)) {
        connection.Open();
        using (SqlCommand command = new SqlCommand(sql, connection)) {
          using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
              Object[] line = new Object[reader.FieldCount];
              for (int i = 0; i < reader.FieldCount; ++i)
                line[i] = reader[i];
              yield return line;
            }
          }
        }
      }
    }
