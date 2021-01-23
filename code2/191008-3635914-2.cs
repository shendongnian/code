    SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        connection.Open();
        // Do work
    }
    finally
    {
        connection.Dispose();
    }
