    using (var connection = new MySqlConnection("connection-string"))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "DELETE FROM tokens WHERE token = @token";
        var token = new MySqlParameter
        {
            ParameterName = "@token",
            MySqlDbType = MySqlDbType.Int32,
            Value = int.Parse(passbox.Text)
        };
        command.Parameters.Add(token);
        connection.Open();
        command.ExecuteNonQuery();                
    }
