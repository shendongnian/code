    string sqlquery = "INSERT INTO [Users] (FirstName,LastName,Username,Password) VALUES ( " +FirstNameTextBox.Text + " ,";
    sqlquery +=  LastNameTextBox.Text+ ",";
    sqlquery +=  + UsernameTextBox.Text+ ",";
    sqlquery =  PasswordTextBox.Text + " )";
    SqlCommand command = new SqlCommand(sqlquery , connection);
        
