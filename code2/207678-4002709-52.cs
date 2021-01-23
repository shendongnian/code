    SqlConnection connection;
    try
    {
       connection = new SqlConnection("connection string here");
       SqlCommand command = new SqlCommand("sql query here", connetion);
      
       connection.Open();
       SqlDataReader reader = command.ExecuteReader(); 
       //do something with the data reader here
    }
    finally
    {
        connection.Close();
    }
