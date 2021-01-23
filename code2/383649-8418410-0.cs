    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        // Start a local transaction.
        SqlTransaction sqlTran = connection.BeginTransaction();
    
        // Enlist a command in the current transaction.
        SqlCommand command = connection.CreateCommand();
        command.Transaction = sqlTran;
    
        try
        {
            // Execute two separate commands.
            command.CommandText =
              "INSERT INTO Order ...";
            command.ExecuteNonQuery();
