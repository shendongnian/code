    public Entity GetById(int id)
    {
        return Cache.GetOrCreate($"id:{id}", cacheEntry =>
        {
            return db.GetById(id);
        });
    }
