        SqlConnection connection = new SqlConnection(ConnectionString);
        SqlCommand command = new SqlCommand("MyStoredProcName", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlParameter submitParam = new SqlParameter("@pGuid", SqlDbType.String);
        //use SqlDbType.Bit if  you are returning true/false.      
        SqlParameter returParameter = new SqlParameter("@ReturnedParam", SqlDbType.String);  
        returParameter.Direction = ParameterDirection.Output;
        
        connection.Open();
        foreach (string s in textLine)
        {
                returnString.Value = s;            
                command.Parameters.Clear(); 
                command.Parameters.Add(submitParam); 
                command.Parameters.Add(returParameter);         
                
                try
                {                
                        command.ExecuteNonQuery();
                        store the returned string in DataTable, BindingList<string> or any, but this is how to retrieve it:
 	                Convert.ToString(Command.Parameters["@ReturnedParam"].Value, CultureInfo.CurrentCulture)
                }
                catch (Exception ex)
                {
 	                ;;
                }
        }
        
        connection.Close();
        
        Do the grid binding here
