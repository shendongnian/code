    string commandText = "UPDATE Seatlist " +
                         "SET [2] = @Seat " +
                         "WHERE FlightNo = @FlightNo AND Origin = @Origin";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
    
        command.Paramters.AddWithValue("@Seat", SeatNo.Text);
        command.Parameters.AddWithValue("@FlightNo", FlightNo.Text);
        command.Parameters.AddWithValue("@Origin", Origin.Text);
        // ... rest of your code
    }
