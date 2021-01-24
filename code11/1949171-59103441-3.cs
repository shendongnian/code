    public List<Entity> Entities
    {
        get { return Cache.GetOrCreate($"entities", cacheEntry =>
                     {
                         // Create an empty list of entities
                         return new List<Entity>();
                     }); 
        }
        set { Cache.Set($"entities", value); }
    }
