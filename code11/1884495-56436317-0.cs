    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value, new 
        JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
    }
