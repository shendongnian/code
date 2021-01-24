    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            // connection is valid
        }
        catch (SqlException)
        {
            // connection is not valid
        }
    }
