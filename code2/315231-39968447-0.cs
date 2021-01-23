    string connectionString = ConfigurationManager.ConnectionStrings["MySqlServer"]?.ConnectionString;
    //------------------------------------------------------------------------HERE-^-HERE-------------
    
    if (string.IsNullOrWhiteSpace(connectionString))
    {
        // Don't even bother trying to open the connection.
        // Log the error and either rethrow the exception (throw;) or exit from your current context (return;).
        //return;
        //throw;
    }
    // If your code has made it this far, it means you have a valid connection string.  Now try to use it.
    using (var sqlConnection = new SqlConnection(connectionString))
    {
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand)
        {
            // Do stuff.
        }
    }
