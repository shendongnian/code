          using (SqlCommand cmd= new SqlCommand())
          {
               cmd.Text= ...;
               cmd.CommandType = CommandType.StoredProcedure;
               SqlParameter outParam = cmd.Parameters.Add("@guidid", SqlDbType.Uniqueidentifier);
               outParam.Direction = ParameterDirection.Output;
            
               using (var connection = new SqlConnection(this.myConnectionString))
               {
                connection.Open();
                cmd.Connection = connection;
                
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                 //    put your sql catches etc. here..
                  throw;
                }  
              }  
           var outValue = outParam.Value; 
           //query outValue e.g. ToString()   
           }
