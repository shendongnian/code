    private bool DoesIDExist(string ID)
    {
        string filePath = ""; //TODO
        string hashShortPass = ""; //TODO
        DataTable temp = new DataTable();
        bool result = false;
        
        // Creating a connection string. Using placeholders make code
        // easier to understand.
        string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};
              Persist Security Info=False; Jet OLEDB:Database Password={1};";
        
        using (OleDbConnection connection = new OleDbConnection())
        {
            string sql = string.Format
                ("SELECT FROM PersonalData WHERE DataID = '{0}'", ID);
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            {
                // Creating command object.
                // Using a string formatting let me to insert data into
                // place holders I have used earlier.
                connection.ConnectionString =
                    string.Format(connectionString, filePath, hashShortPass);
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
