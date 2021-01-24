    private static IEnumerable<IDataRecord> ReadSqlRecords(string sql) {
      //TODO: Put connection string here
      //TODO: I've assumed you work with MS SQL; if not replace SqlConnection 
      using (var conn = new SqlConnection("ConnectionStringHere")) {
        conn.Open();
        using (var q = conn.CreateCommand()) {
          q.CommandText = sql;
          using (var reader = q.ExecuteReader()) {
            while (reader.Read())
              yield return reader;
          }
        }
      }
    }
