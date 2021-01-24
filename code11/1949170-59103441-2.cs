    public class EntityRepository
    {
        public Entity GetById(int id)
        {
            List<Entity> entities = Cache.GetOrCreate($"entities", cacheEntry =>
            {
                // Create an empty list of entities
                return new List<Entity>();
            });
            // Look for the entity
            var entity = entities.Where(e => e.id == id).FirstOrDefault();
            // if not there, then add it to the cached list
            if (entity == null)
            {
                entity = db.GetById(id);
                entities.Add(entity)
                // Update the cache
                Cache.Set($"entities", entities);
            }
            return entity;
        }
        public Entity GetByName(string name)
        {
            // Same thing with id    
        }
        public void RemoveById(int id)
        {
            // load the list, remove item and update cache
        }
    }
