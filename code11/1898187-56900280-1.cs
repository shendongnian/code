    public static int updateMytable(string accessCode, string response) {
      if (string.IsNullOrEmpty(accessCode))
        return 0; 
      using (OracleConnection conn = DB.GetConnection()) {
        conn.Open();
        using (OracleCommand cmd = new OracleCommand()) {
          // When binding varaibles, use their names, not positions
          cmd.BindByName = true;
          cmd.Connection = conn;
          cmd.CommandText = 
            @"update mytable 
                 set response_id   = :p_response, 
                     response_date =  sysdate  
               where access_code   = :p_access_code"; 
          cmd.Parameters.Add(":p_response", OracleDbType.Varchar2);
          cmd.Parameters.Add(":p_access_code", OracleDbType.Varchar2);   
          cmd.Parameters[":p_response"].Value = string.IsNullOrEmpty(response) 
            ? (object) (DBNull.Value) 
            : response;
          cmd.Parameters[":p_access_code"].Value = accessCode;  
          return cmd.ExecuteNonQuery();  
        }
      }
    }
