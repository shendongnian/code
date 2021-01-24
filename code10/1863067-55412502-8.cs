    private List<bool> ExecuteResults() {
      List<bool> result = new List<bool>();
    
      using (var con = new SqlConnection(ConnectionStringHere)) {
        con.Open();
    
        string sql = 
          @"select nomeItem 
              from tabList 
             where selection = 1";
    
        using (SqlCommand cmd = new SqlCommand(sql, con)) {
          using (var reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              string path = Convert.ToString(reader[0]);
    
              using (Process process = Process.Start(path)) {
                process.WaitForExit();
    
                result.Add(process.ExitCode == 1); 
              }
            }
          } 
        }
      }
      return result;
    }
