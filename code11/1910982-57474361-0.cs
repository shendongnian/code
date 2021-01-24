    using (var connection = new SqlConnection())
    {
        connection.ConnectionString = GetConnectionStringForUser(user);
        ...
    }
