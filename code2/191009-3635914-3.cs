    using(SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        // Do Work
    }
    // First connection is disposed
    using(SqlConnection connection = new SqlConnection(connectionString2))
    {
        // Do More Work
    }
    // Second connection is disposed
    using(SqlConnection connection = new SqlConnection(connectionString3))
    {
        // Do More Work
    }
    // Last connection is dipsosed
