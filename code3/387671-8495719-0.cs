    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        var command = new OleDbCommand("INSERT INTO Nodes [rest of your query goes here]", connection);
        command.Parameters.Add( ... ) // add parameters as needed
        connection.Open();
        command.ExecuteNonQuery();
    }
