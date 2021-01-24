    public class EntityRepository
    {
        public Entity GetById(int id)
        {
            return Cache.GetOrCreate($"id:{id}", cacheEntry =>
            {
                return db.GetById(id);
            });
        }
        public Entity GetByName(string name)
        {
            return Cache.GetOrCreate($"name:{name}", cacheEntry =>
            {
                return db.GetByName(name);
            });
        }
        public void RemoveById(int id)
        {
            db.RemoveById(id);
            if (Cache.TryGetValue(id, out Entity entity))
            {
                Cache.Remove($"id:{entity.Id}");
                Cache.Remove($"name:{entity.Name}");
            }
        }
    }
