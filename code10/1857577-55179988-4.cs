    // Dangerous practice: what if I put commandText "drop table MyTable"?
    public static List<T> ExecuteQuery<T>(string connection, 
                                          string commandText, 
                                          Func<SqlDataReader, List<T>> myMethodName) {
      //ToDo: Validate parameters here
    
      using (var con = new SqlConnection(connection)) {
        con.Open();
    
        using (var cmd = new SqlCommand(commandText, con)) {
          // IDataReader is IDisposable as well       
          using (var reader = cmd.ExecuteReader()) {
            return myMethodName(reader);
          } 
        }
      }  
    }
