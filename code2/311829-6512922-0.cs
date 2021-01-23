    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
  
        //add parameters here
  
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
