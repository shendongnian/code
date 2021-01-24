      // -1 Account does't exist 
      //  0 Account exists and belongs to the user
      //  1 Account exists and belongs to different user
      public int UserLogStatus(string login, string password) {
        //DONE: do not reuse connection, but create a new one
        using (var con = new MySqlConnection(ConnectionStringHere)) {
          con.Open();
          //DONE: keep sql readable
          //DONE: make sql parametrized 
          string sql = 
            @"select userstatus
                from png_users 
               where username = @prm_username and
                     password = @prm_password";  
          //DONE: wrap IDisposable into using 
          using (MySqlCommand query = new MySqlCommand(sql, con)) {
            //TODO: better create params explicitly, Parameters.Add(name, type).Value = ...
            query.Parameters.AddWithValue("@prm_username", login);
            query.Parameters.AddWithValue("@prm_password", pasword);
            using (var reader = query.ExecuteReader()) {
              if (reader.Read()) 
                return Convert.ToInt32(reader[0]);
              else
                return -1;
            }
          }
        }
      } 
