    private void ApplyExecuteResults(IEnumerable<bool> results) {
      using (var con = new SqlConnection(ConnectionStringHere)) {
        con.Open();
    
        string sql = 
          @"insert into tabList(resItem) 
                 values (@prm_resItem)";
    
        using (SqlCommand cmd = new SqlCommand(sql, con)) {
          //TODO: change to Add("@prm_resItem", RdbmsType) and provide RdbmsType
          cmd.Parameters.AddWithValue("@prm_resItem", "****");
    
          foreach (var item in result) {
            cmd.Parameters[0].Value = item ? "PASS" : "FAIL"; 
          
            cmd.ExecuteNonQuery();
          }
        } 
      }
    }
