    using(var dbConnection = new SqlConnection(cnString))
    {
          dbConnection.Open();
        
          using(var insertCmd = new SqlCommand(@"INSERT INTO Measurements (Distance, DateTime) VALUES(@Distance, @DateTime)", dbConnection))
          {
              insertCmd.Parameters.Add("@Distance", SqlDbType.VarChar).Value = dataIn;
              insertCmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = dt;
              insertCmd.ExecuteNonQuery();
           }
    }
