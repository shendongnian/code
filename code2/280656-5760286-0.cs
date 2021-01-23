    using (OdbcConnection connection = SomeMethodReturningConnection())
    using (OdbcCommand command = SomeMethodReturningCommand())
    {
        command.Parameters.Add(new OdbcParameter("@username", username.Text));
        command.CommandText = "Select Count(*) From Users where Username = ?";
        connection.Open();
        int output = (int)command.ExecuteScalar();
    
        if (output > 0)
        {
            // username already exists, provide appropriate action
        }
        else
        {
            // perform insert 
            // note: @username parameter already exists, do not need to add again
            command.Parameters.Add(new OdbcParameter("@password", password.Text));
            command.CommandText = "Insert Into Users (Username, Password) Values (?,?)**";
            command.ExecuteNonQuery();
        }
    }
