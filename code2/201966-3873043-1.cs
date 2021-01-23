    public void CreateCustomer(string userName, string email)
    {
        const string insertCustomerCommand = "INSERT INTO Customers (userName, email) VALUES (@userName, @email)";
        var connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"];
        var sqlConnection = new SqlConnection(connectionString.ToString());
        var sqlCommand = new SqlCommand(insertCustomerCommand, sqlConnection);
        sqlCommand.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;
        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
        
        // Eventually wrap in a try catch statement to handle any sql exceptions.
        sqlCommand.ExecuteNonQuery();
    }
