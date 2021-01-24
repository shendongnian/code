    using(var connection = new NpgsqlConnection(ConnectionString))
    {
        var results = await connection.ExecuteAsync(
            "user_create",
            ToParam(new User
            {
                Id = new Guid("38745b2e-436c-4593-827e-6ae123f12db5"),
                Name = "John",
                Email = "j.smith@example.com"
            }),
            commandType: CommandType.StoredProcedure);
    }
    
    private DynamicParameters ToParam<T>(T obj)
    {
        var dp = new DynamicParameters();
        var properties = typeof(T).GetProperties();
        foreach(var property in properties)
        {
            dp.Add($"_{SnakeCase(property.Name)}", property.GetValue(obj));
        }
        return dp;
    }
    
    private string SnakeCase(string input)
    {
        if(string.IsNullOrWhiteSpace(input))
        {
            return input;
        }
        var startUnderscores = Regex.Match(input, @"^_+");
        return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLowerInvariant();
    }
