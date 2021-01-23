    using(var connection = new SqlConnection(myConnectionString))
    {
        connection.Open();
        using(var command = connection.CreateCommand())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = mySql;
            var result = (int)command.ExecuteScalar();
        }
    }
