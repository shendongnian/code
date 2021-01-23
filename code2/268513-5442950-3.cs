    SqlConnection connection;
    
    try
    {
        connection = new SqlConnection(...);
    
        SqlCommand command;
    
        try
        {
            command = connection.CreateCommand();
    
            // Do something with the command.
        }
        finally
        {
            if(command != null)
            {
                command.Dispose();
            }
        }
    }
    finally
    {
        if(connection != null)
        {
            connection.Dispose();
        }
    }
