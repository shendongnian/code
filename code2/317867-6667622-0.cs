    protected void CheckBoxProcess_CheckedChanged(object sender, EventArgs e)
    {
        bool update = Convert.ToBoolean(DefaultGrid.SelectedValue);
    
        // determine your first name and last name values
        string firstName = .......;  
        string lastName = .......;
        
        UpdateYourData(update, firstName, lastName);
    }
    
    private void UpdateYourData(bool isProcessed, string firstName, string lastName)
    {
        Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/Cabot3");
        ConnectionStringSettings connectionString = rootWebConfig.ConnectionStrings.ConnectionStrings["secureodb"];
    
        string updateStmt = "UPDATE dbo.SecureOrders SET processed = @Processed " + 
                            "WHERE fName LIKE @firstName AND lName LIKE @lastName";
    
        using (SqlConnection connection = new SqlConnection(connectionString.ToString()))
        using (SqlCommand _update = new SqlCommand(updateStmt, connection))
        {
            _upate.Parameters.Add("@Processed", SqlDbType.Bit).Value = isProcessed;
            _upate.Parameters.Add("@firstName", SqlDbType.VarChar, 100).Value = firstName;
            _upate.Parameters.Add("@lastName", SqlDbType.VarChar, 100).Value = lastName;
        
            connection.Open();
            _update.ExecuteNonQuery();
            connection.Close();
        }
    }
