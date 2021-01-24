    RedisCacheClient _client;
    ...
    IRedisDatabase redisDatabase = _client.GetDb(1);
    IEnumerable<string> keys = await redisDatabase.SearchKeysAsync("*");
    IDatabase database = redisDatabase.Database;
    Dictionary<string, RedisType> keysWithTypes = keys.ToDictionary(k => k, k => database.KeyType(k));
