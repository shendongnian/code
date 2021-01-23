    public abstract class BaseRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        protected BaseRepository()
        {
        }
        
        protected abstract DatabaseContext GetContext();
    }
