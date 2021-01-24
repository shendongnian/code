    public bool IsLogin(string user, string pass) 
    {
        // prepare the queries with parameters with '@' and parameter name
        const string query = "SELECT count(username) from utiliz WHERE username = @username AND password = @password";
        const string query_update = "UPDATE utiliz SET logat = @logat WHERE username = @username";
        // prepare the encrypted password
        string encryptedPass = GetSha1(pass);
    
        // use a result variable to use as the function result
        bool result = false;
        try
        {
            if (OpenConnection())
            {
                // start a transaction from the connection object
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try    
                    {
                        int userFound = 0;
                        // prepare the MySqlCommand to use the query, connection and transaction.
                        using (MySqlCommand userCommand = new MySqlCommand(query, conn, tran))
                        {
                            userCommand.Parameters.AddWithValue("@username", user);
                            userCommand.Parameters.AddWithValue("@password", encryptedPass);
    
                            userFound = (int) userCommand.ExecuteScalar();
                        }  
    
                        if (userFound > 0)
                        {
                            // prepare the MySqlCommand to use the query, connection and transaction to update data
                            using (MySqlCommand logatCommand = new MySqlCommand(query_update, conn, tran))
                            {
                                logatCommand.Parameters.AddWithValue("@logat", DateTime.Now);
                                logatCommand.Parameters.AddWithValue("@username", user);                        
    
                                logatCommand.ExecuteNonQuery();
                            }
                        }  
    
                        // commit the transaction
                        tran.Commit();
    
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        // perform some log with ex object. 
                        
                        tran.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }            
            }
        }
        catch (Exception e)
        {
            // perform some log...
    
            return false;
        }
    
        return result;
    }
