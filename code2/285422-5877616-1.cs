    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        
        	
        using (SqlCommand command = new SqlCommand())
        {
          //Command 1
        } // command is disposed.
    
        using (SqlCommand command = new SqlCommand())
        {
          //SqlCommand 2
        } // command is disposed.
       //Or just call command.Dispose(); on the command after you're done.
    } // the SqlConnection will be disposed
