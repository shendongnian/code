    public void Insert(string strSQL, string[,] parameterValue)
            {
    
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(strSQL, connection);
    
                    //add parameters
                    for (int i = 0; i < (parameterValue.Length / 2); i++)
                    {
                        cmd.Parameters.AddWithValue(parameterValue[i, 0], parameterValue[i, 1]);
                    }
    
                    //Execute command
                    cmd.ExecuteNonQuery();
    
                    //close connection
                    this.CloseConnection();
                }
            }
