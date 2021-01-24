    ...
    //DONE: wrap IDisposable into using
    using (MySqlConnection MyConn2 = new MySqlConnection(conn_string.ToString())) {
      MyConn2.Open();
      //DONE: make sql readable
      //DONE: make sql paramterized
      string Query = 
        @"delete 
            from directory.userdata 
           where IdCardNo = @prm_IdCardNo";
      using (MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2)) {
        //TODO: Add("@prm_IdCardNo", RDBMSType).Value = is a better option
        MyCommand2.Parameters.AddWithValue("@prm_IdCardNo", inputt);
        // ExecuteNonQuery - just execute, we have nothing to read
        int affected = MyCommand2.ExecuteNonQuery();
        // If you want to know if table has been modified
        if (affected > 0) {
          // Some records are affected (deleted)
        }
      } 
    } 
