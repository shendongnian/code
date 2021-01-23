        string sqlquery = "INSERT INTO [Users] (FirstName,LastName,UserName,Password) VALUES (@FirstName,@LastName,@UserName,@Password)";
        SqlCommand command = new SqlCommand(sqlquery , connection);
        //FirstName***********
        string firstName = FirstNameTextBox.Text;
        command.Parameters.AddWithValue("FirstName", firstName);
        //LastName************
        string lastName = LastNameTextBox.Text;     
        command.Parameters.AddWithValue("LastName", lastName);
        //Username*************
        string username = UsernameTextBox.Text;     
        command.Parameters.AddWithValue("UserName", username);
        //Password*************
        string password = PasswordTextBox.Text;    
        command.Parameters.AddWithValue("Password", password);
      
        ...........
