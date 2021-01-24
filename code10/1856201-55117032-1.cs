    private static bool createRecord(string table, 
                                     IDictionary<String,String> data, 
                                     System.Data.IDbConnection conn, 
                                     OdbcTransaction trans) {
      [... some other code ...]
 
      // using: do not call Dispose() explicitly, but wrap IDisposable into using
      using (var command = ...) {
        try {
          // Normal flow:
          command.CommandText = sb.ToString();
          // true if and only if exactly one record affected
          return command.ExecuteNonQuery() == 1; 
        }
        catch (DbException) {
          // Exceptional flow (all database exceptions)
          return false;
        }
      }
    }   
