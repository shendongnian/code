    string insertSql = 
        "INSERT INTO aspnet_GameProfiles(UserId,GameId) VALUES(@UserId, @GameId)SELECT SCOPE_IDENTITY()";
    
    int primaryKey;
    
    using (SqlConnection myConnection = new SqlConnection(myConnectionString))
    {
       myConnection.Open();
    
       SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
    
       myCommand.Parameters.AddWithValue("@UserId", newUserId);
       myCommand.Parameters.AddWithValue("@GameId", newGameId);
    
       primaryKey = Convert.ToInt32(myCommand.ExecuteScalar());
    
       myConnection.Close();
    }
