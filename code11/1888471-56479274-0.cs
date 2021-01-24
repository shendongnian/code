      public bool IsUserLogged(string login, string password) {
        //DONE: do not reuse connection, but create a new one
        using (var con = new MySqlConnection(ConnectionStringHere)) {
          con.Open();
          //DONE: keep sql readable
          //DONE: make sql paramterized 
          string sql = 
            @"select 1 -- we don't want all - * - fields
                from png_users 
               where username = @prm_username and
                     password = @prm_password and 
                     userstatus = 1";  
          //DONE: wrap IDisposable into using 
          using (MySqlCommand query = new MySqlCommand(sql, con)) {
            //TODO: better create params explicitly, Parameters.Add(name, type).Value = ...
            query.Parameters.AddWithValue("@prm_username", login);
            query.Parameters.AddWithValue("@prm_password", pasword);
            using (var reader = query.ExecuteReader()) {
              return reader.Read();
            }
          }
        }
      } 
