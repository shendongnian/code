    public class GenericRepository
    {
        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            var collection = GetCollection<TEntity>();
            collection.Save<TEntity>(entity);
        }
    
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
             // ...
        }
    }
