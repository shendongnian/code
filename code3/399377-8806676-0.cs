     string commandText = "UPDATE Sales.Store SET Demographics = @demographics "
        + "WHERE CustomerID = @ID;";
     SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@ID", SqlDbType.Int);
        command.Parameters["@ID"].Value = customerID;
        // Use AddWithValue to assign Demographics.
        // SQL Server will implicitly convert strings into XML.
        command.Parameters.AddWithValue("@demographics", demoXml);
