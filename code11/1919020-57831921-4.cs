    public static Task<bool> CheckForCredentialsAsync(string username, string password)
    {
        var query = "SELECT 1 FROM Account WHERE Username = @USERNAME AND Password = @PASSWORD";
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(query, connection))
        {
            var parameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = @USERNAME,
                    SqlDbType = SqlDbType.Varchar,
                    Size = 100,
                    Value = username
                },
                new SqlParameter
                {
                    ParameterName = @PASSWORD,
                    SqlDbType = SqlDbType.Varchar,
                    Size = 300,
                    Value = password
                }
            };
            command.Parameters.AddRange(parameters);
            await connection.OpenAsync();
            var rowExists = await command.ExecuteScalarAsync();
            return rowExists != null;
        };
    }
