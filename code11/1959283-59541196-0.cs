    private int NextInvoiceNumber() {
      //TODO: put the right connection string here
      using(var conn = new SqlConnection(ConnectionStringHere)) {
        conn.Open();
    
        string sql = 
          @"SELECT MAX(invoid) 
              FROM sales";
    
        using (var cmd = new SqlCommand(sql, conn)) {
          var raw = cmd.ExecuteScalar() as string;
    
          return raw == null 
            ? 1                                        // no invoces, we start from 1
            : int.Parse(raw.Trim('e', 'E', '-')) + 1;
        }
      }
    }
