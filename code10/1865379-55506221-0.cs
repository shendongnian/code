    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable
        where TEntity : class, new() {
        
        //...
        
        public BaseRepository(IDbContextBase context) {
            Context = context;
            Set = Context.Set<TEntity>();
        }
        
        //...
    }
