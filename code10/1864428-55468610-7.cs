    public static IEnumerable<IDataRecord> DbQueryToArray(string sql) {
      if (null == sql)
        throw new ArgumentNullException(nameof(sql));
      //TODO: do not hardcode connetcion string but read it (say, from Settings)
      string SqlCString = "connString";
      //DONE: Wrap IDisposable into using
      using (SqlConnection connection = new SqlConnection(SqlCString)) {
        connection.Open();
        //DONE: Wrap IDisposable into using
        using (SqlCommand command = new SqlCommand(sql, connection)) {
          //DONE: Wrap IDisposable into using
          using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
              yield return reader as IDataRecord;
            }
          }
        }
      }
    }
