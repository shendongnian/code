    private void ApplyExecuteResults(IEnumerable<Tuple<string, bool>> results) {
      using (var con = new SqlConnection(ConnectionStringHere)) {
        con.Open();
    
        string sql = 
          @"insert into tabList (
               nomItem,
               resItem) 
            values (
              @prm_nomItem,
              @prm_resItem)";
    
        using (SqlCommand cmd = new SqlCommand(sql, con)) {
          cmd.Parameters.Add("@prm_nomItem", SqlDbType.VarChar);
          cmd.Parameters.Add("@prm_resItem", SqlDbType.VarChar);
    
          foreach (var item in results) {
            cmd.Parameters[0].Value = item.Item1; 
            cmd.Parameters[1].Value = item.Item2 ? "PASS" : "FAIL"; 
          
            cmd.ExecuteNonQuery();
          }
        } 
      }
    }
