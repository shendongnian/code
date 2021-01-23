    using (OleDbConnection connection = SomeMethodReturningConnection())
    using (OleDbCommand command = SomeMethodReturningCommand())
    {
        command.Parameters.Add(new OleDbParameter("@username", username));
        command.CommandText = "Select Count(*) From Users where Username = @username";
        int output = (int)command.ExecuteScalar();
        if (output > 0)
        {
            // username already exists, provide appropriate action
        }
        else
        {
            // perform insert 
            // note: @username parameter already exists, do not need to add again
            command.Parameters.Add(new OleDbParameter("@password", password));
            command.CommandText = "Insert Into Users (Username, Password) Values (@username, @password)";
            command.ExecuteNonQuery();
        }
    }
