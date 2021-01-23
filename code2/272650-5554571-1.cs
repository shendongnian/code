    public class GenericRepository<TEntity> where TEntity : class
    {
        public void Insert(TEntity entity) 
        {
            var collection = GetCollection<TEntity>();
            collection.Save<TEntity>(entity);
        }
    }
    
    public class UserRepository : GenericRepositry<User>
    {
        //...
    }
