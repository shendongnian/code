    using(myReader = cmd.ExecuteReader())
    {
      while(myReader.Read())
      {
        string info = myReader.GetString("info");
        /* Do stuff */
        using(SqlConnection logConn = new SqlConnection(...))
        {
          logConn.Open();
          string queryLog = "INSERT INTO ....;
          MySqlCommand cmdLog = new MySqlCommand(queryLog, connection);
          cmdLog.ExecuteNonQuery();
        }
      }
    }
