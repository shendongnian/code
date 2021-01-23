    if (connection.State == System.Data.ConnectionState.Open)
    {
         // ahoy, mate!
    }
    else
    {
        connection.Open();
        // here be dragons
    }
