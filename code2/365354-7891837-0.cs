     using(qlConnection connection = new SqlConnection(connectionString))
     {
      using(SqlCommand command = new SqlCommand(selectString,connection))
      {
         connection.Open();
         reader = command.ExecuteReader(); 
         // rest of your code.
       }
    }
