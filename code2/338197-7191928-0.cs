     dbConn.Open();
    
      if (sqlCommand.Connection.State == ConnectionState.Open)
      {
          dbConn.Close();
      }
      sqlCommand.ExecuteNonQuery();
