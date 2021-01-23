    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        var query = "INSERT INTO Nodes (nID, csNumber) " +
                    "VALUES (?, ?)";
        var command = new OleDbCommand( query, connection);
        command.Parameters.AddWithValue("@nID", nNodeID);
        command.Parameters.AddWithValue("@csNumber", strNumber);
        connection.Open();
        command.ExecuteNonQuery();
    }
