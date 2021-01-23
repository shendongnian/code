    connection.Open();
    string sqlquery = "INSERT INTO [Users] (FirstName,LastName,Username,Password) VALUES ( " +FirstNameTextBox.Text + " ,";
    
            sqlquery +=  LastNameTextBox.Text+ ",";
            sqlquery +=  + UsernameTextBox.Text+ ",";
            sqlquery =  PasswordTextBox.Text + " )";
            SqlCommand command = new SqlCommand(sqlquery , connection);
    
            if (PasswordTextBox.Text == ReTypePassword.Text)
            {
                command.ExecuteNonQuery();
            }
            else
            {
                ErrorLabel.Text = "Sorry, You didnt typed your password correctly.  Please type again.";
            }
    
            connection.Close();
