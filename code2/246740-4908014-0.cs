    using ( var conn = new Connection( connString ) )
    {
      conn.Open();
      var sql = "my sql";
      using( var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn) )
      {
        cmd.ExecuteNonQuery();
      }
    }
