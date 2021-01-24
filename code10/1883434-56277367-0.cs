    services.AddTransient<IDatabase>((sp) =>
    {
        return RedisConnectionFactory
            .GetConnection().GetDatabase(int.Parse(ConfigurationManager.AppSettings["RedisConnectionIdsDatabase"]));
    });
