    private bool TestUser(string connectionString, int userID)
    {
    	var result = true;
    
    	using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    		connection.Open();
    
    		var command = connection.CreateCommand();
    		var transaction = connection.BeginTransaction();
    
    		command.Connection = connection;
    		command.Transaction = transaction;
    
    		try
    		{
    			command.CommandText = "DELETE User WHERE UserID = " + userID.ToString();
    			command.ExecuteNonQuery();
    			transaction.Rollback();
    		}
    		catch
    		{
    			result = false;
    		}
    	}
    
    	return result;
    }
