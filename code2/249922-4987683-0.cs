                using (var con = new OleDbConnection(_constring))
                {
                    con.Open();
                    using (
                        var cmd =
                            new OleDbCommand(
    "UPDATE LogIn SET Username=@Username, Password=@Password WHERE (ID = @Id)",
                                con))
                    {
                        try
                        {
    
                            cmd.Parameters.AddWithValue("@Username",EditUsernameTextBox.Text);
                            cmd.Parameters.AddWithValue("@Password",EditPasswordTextBox.Text);
                            cmd.Parameters.AddWithValue("@Id",IDTextBox.Text);
    
    
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                        finally
                        {
                            con.Close();
                        }
    
                    }
                
        
