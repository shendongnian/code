    string _connectionString = string.Empty;
            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = new SqlConnection();
    
      
    
             ._connectionString = config["connectionString"];
    
               
             sqlConnection.ConnectionString = "<your connection string>";
             sqlCommand.Connection = sqlConnection;
             sqlCommand.CommandType = CommandType.StoredProcedure;
                	
    	//add your parameters here
    	sqlCommand.Parameters.Add("@ParameterNameWithinProcedure", <your value goes here>);
    	sqlCommand.Parameters.Add("@ParameterNameWithinProcedure", <your value goes here>);
    	sqlCommand.Parameters.Add("@ParameterNameWithinProcedure", <your value goes here>);
    	//Repeat for each parameter in your record.
    
    	int returnVal = 0;
                
            sqlCommand.CommandText = "< insert record stored procedure name"
             
    
            try
            {
               sqlConnection.Open();
               using (sqlCommand)
               {
                  returnVal = sqlCommand.ExecuteNonQuery();
               }
            }
            catch (Exception ex)
            {
              //possibly put some logging inforaation here
            }
            finally
            {
                sqlConnection.Close();
            }
               
