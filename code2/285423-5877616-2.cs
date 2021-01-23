    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string sql1 = "SELECT ID,FirstName,LastName FROM VP_PERSON";
        string sql2 = "SELECT Address,City,State,Code FROM VP_ADDRESS";
        	
        using (SqlCommand command = new SqlCommand(sql1,connection))
        {
            //Command 1
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // reader.Read iteration etc
            }
  
        } // command is disposed.
    
        using (SqlCommand command = new SqlCommand(sql2,connection))
        {
            //Command 1
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // reader.Read iteration etc
            }
        } // command is disposed.
       // If you don't using using on your SqlCommands you need to dispose of them 
       // by calling command.Dispose(); on the command after you're done.
    } // the SqlConnection will be disposed
