    using (SqlConnection connection = new SqlConnection(connectionString)) 
    {    
      int employeeID = findEmployeeID();    
      try    
      {
    
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateEmployeeTable", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
                command.CommandTimeout = 5;
    
                command.ExecuteNonQuery();    
       } 
       catch (Exception) 
       { 
          /*Handle error*/ 
       }
    
    }
