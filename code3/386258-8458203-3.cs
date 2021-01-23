    using(var conn = new MySqlConnection(DatabaseHelper.getConnectionString())) 
    {
      using (var cmd = conn.CreateCommand()) 
      { 
          conn.Open(); 
          cmd.CommandType = CommandType.Text;
          //Parameterize your queries!
          cmd.CommandText = "SELECT username FROM characters WHERE id=?"; //Use ? as placeholder for parameters, and add parameters in the order they appear in your query.
          cmd.Parameters.Add(new MySqlParameter("@userid", MySqlDbType.Int, userid));
          
          using(IDataReader reader = cmd.ExecuteReader())
          { 
              //You should only expect one record. You might want to test for more than 1 record.
              if (reader.Read()) 
              { 
                  user = reader.GetString(reader.GetOrdinal("username")); //Think also about null value checking.
              } 
          } 
      }
    }
