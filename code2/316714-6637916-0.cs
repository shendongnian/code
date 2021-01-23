    // instantiate and open connection
    			conn =  new 
    				SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
    			conn.Open();
    
    			// don't ever do this!
    //			SqlCommand cmd = new SqlCommand(
    //				"select * from Customers where city = '" + inputCity + "'";
    
    			// 1. declare command object with parameter
    			SqlCommand cmd = new SqlCommand(
    				"select * from Customers where city = @City", conn);
    
    			// 2. define parameters used in command object
    			SqlParameter param  = new SqlParameter();
    			param.ParameterName = "@City";
    			param.Value         = inputCity;
    
    			// 3. add new parameter to command object
    			cmd.Parameters.Add(param);
    
    			// get data stream
    			reader = cmd.ExecuteReader();
    
    			// write each record
    			while(reader.Read())
    			{
    				Console.WriteLine("{0}, {1}", 
    					reader["CompanyName"], 
    					reader["ContactName"]);
    			}
    		}
    		finally
    		{
    			// close reader
    			if (reader != null)
    			{
    				reader.Close();
    			}
    
    			// close connection
    			if (conn != null)
    			{
    				conn.Close();
    			}
    		}
