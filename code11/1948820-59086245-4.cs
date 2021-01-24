    string sql = "select * from x where path = ?path";
    
    using (MySqlCommand command = new MySqlCommand(sql, connection))
    {
        var pathParam = new MySqlParameter("path",
          @"c:\something\somethingelse\anotherthing.thing");
    
        command.Parameters.Add(pathParam);
        var results = command.ExecuteReader();
    }
