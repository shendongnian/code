    public class InMemoryRepository : IRepository
    {
        private readonly IList<object> entities = new List<object>();
        
        public T Get<T>(object id)
        {
            return entities.OfType<T>.SingleOrDefault(e => e.ID == id);
        }
        
        public IList<T> GetAll<T>()
        {
            return entities.OfType<T>.ToList();
        }
        
        public IQueryable<T> Query<T>()
        {
            return GetAll<T>.AsQueryable();
        }
    }
