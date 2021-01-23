    ....
    string queryString = 
         "UPDATE TABLE cottonpurchase SET slipno=@slipno WHERE farmercode=@farmercode"; 
    try       
    {          
      connection.Open();          
      SqlCommand command = new SqlCommand(queryString, connection);
      
      //define parameters used in command object
      SqlParameter param  = new SqlParameter();
      param.ParameterName = "@slipno";
      param.Value         = inputfromsomewhere;
      SqlParameter param  = new SqlParameter();
      param.ParameterName = "@farmercode";
      param.Value         = inputfromsomewhereelse;
      //add new parameter to command object
      command.Parameters.Add(param);
          
      int result = command.ExecuteNonQuery();          
      //if result = 1 the update is performed         
    } 
    ......  
