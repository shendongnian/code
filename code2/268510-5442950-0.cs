    using(var connection = new SqlConnection(...))
    {
        using(var command = connection.CreateCommand())
        {
            // Do something with the command.
        }
    }
