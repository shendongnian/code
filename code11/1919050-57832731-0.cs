    string commandText = "UPDATE Seatlist " +
                         "SET [2] = @seat " +
                         "WHERE FlightNo = @FlightNo AND Origin = @Origin";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
    
        command.Paramters.AddWithValue("[2]", @seat);
        command.Parameters.AddWithValue("@FlightNo", FlightNo.Text);
        command.Parameters.AddWithValue("@Origin","Origin.Text");
        // ... rest of your code
    }
