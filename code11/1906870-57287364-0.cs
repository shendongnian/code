    // Given a query, return records
    private static IEnumerable<IDataRecord> QueryLines(string query) {
      using (SqlConnection con = new SqlConnection(envDBConnectionString)) {
        con.Open();
    
        using (var q = new SqlCommand(query, con)) {
          using (var reader = q.ExecuteReader()) {
            while (reader.Read())
              yield return reader as IDataRecord;
          }
        }
      }
    }
