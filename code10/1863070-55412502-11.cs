    private void ApplyExecuteResults(IEnumerable<bool> results) {
      using (var con = new SqlConnection(ConnectionStringHere)) {
        con.Open();
    
        string sql = 
          @"insert into tabList(resItem) 
                 values (@prm_resItem)";
    
        using (SqlCommand cmd = new SqlCommand(sql, con)) {
          cmd.Parameters.Add("@prm_resItem", SqlDbType.VarChar);
    
          foreach (var item in results) {
            cmd.Parameters[0].Value = item ? "PASS" : "FAIL"; 
          
            cmd.ExecuteNonQuery();
          }
        } 
      }
    }
