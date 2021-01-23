    public class RedisCache : ICache
    {
    private readonly ConnectionMultiplexer redisConnections;
 
    public RedisCache()
    {
        this.redisConnections = ConnectionMultiplexer.Connect("localhost");
    }
    public void Set<T>(string key, T objectToCache) where T : class
    {
        var db = this.redisConnections.GetDatabase();
        db.StringSet(key, JsonConvert.SerializeObject(objectToCache
                    , Formatting.Indented
                    , new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    }));
    }
 
 
    public T Get<T>(string key) where T :class
    {
        var db = this.redisConnections.GetDatabase();
        var redisObject = db.StringGet(key);
        if (redisObject.HasValue)
        {
            return JsonConvert.DeserializeObject<T>(redisObject
                    , new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    });
        }
        else
        {
            return (T)null;
        }
    }
