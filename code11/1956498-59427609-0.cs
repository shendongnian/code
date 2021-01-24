    using(MySqlConnection conn = ...)
    {
        using(MySqlCommand cmd = ...)
        {
            // open connection
            // execute command
            // close connection (optional - the connection will be closed when 
            //                   it gets disposed, but it's more explicit this way)
        }
    }
