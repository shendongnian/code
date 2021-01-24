    //DONE:  We delete, that why we return bool (has items actually been deleted), note Note
    //TODO: if connStr is static, declare DeleteAllNotes as static as well 
    public bool DeleteAllNotes(int Id) {
      //DONE: Syntax: correct one is "Delete From table Where condition(s)" 
      //DONE: SQL Parametrized; do not hardcode parameters - "{Id}"
      string sql =
         @"delete 
             from Notes 
            where id = @prm_id";
      using (SqlConnection conn = new SqlConnection(connStr)) {
        conn.Open();
        //DONE: wrap IDisposable into using
        using (SqlCommand cmd = new SqlCommand(sql, conn)) {
          cmd.Parameters.Add("@prm_id", SqlDbType.Int).Value = Id;
          return cmd.ExecuteNonQuery() > 0;
        }
      }
    }
