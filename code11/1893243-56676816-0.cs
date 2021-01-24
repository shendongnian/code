    using(var connection = new SqlConnection(...))
    using(var command = new SqlCommand(..., ...))
    {
         connection.Open();
         ...
         using(var reader = command.ExecuteReader())
             while(reader.Read())
             {
    
             }
    }
