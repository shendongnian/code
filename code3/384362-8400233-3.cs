    private bool DoesIDExist(string ID)
    {
        string filePath = ""; //TODO
        string hashShortPass = ""; //TODO
        DataTable temp = new DataTable();
        bool result = false;
        string connectionString =""; //TODO
    
        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
    
                string sql = @"SELECT * FROM PersonalData WHERE DataID = @DataID";
    
    
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                {
                    command.Parameters.Add(new OleDbParameter("@DataID", ID));
    
                    using (OleDbDataAdapter oda = new OleDbDataAdapter(command))
                    {
                        try
                        {
                            oda.Fill(temp);
    
                            if (temp != null && temp.Rows.Count > 0)
                                result = true; //ID exists
    
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
        }
    return result;
    }
