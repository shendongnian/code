        sqlquery +=  LastNameTextBox.Text+ ",";
        sqlquery +=  + UsernameTextBox.Text+ ",";
        sqlquery =  PasswordTextBox.Text + " )";
        SqlCommand command = new SqlCommand(sqlquery , connection);
        
