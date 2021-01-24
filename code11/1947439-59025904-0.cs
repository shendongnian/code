    string commandText = "UPDATE Sales.Store SET Demographics = @demographics "
            + "WHERE CustomerID = @ID;";
    
        SqlConnection connection = new SqlConnection(connectionString)
            SqlCommand command = new SqlCommand(commandText, connection);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = customerID;
    
            
            command.Parameters.AddWithValue("@demographics", demoXml);
