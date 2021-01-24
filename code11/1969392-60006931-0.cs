    public class IDataContext : IDisposable
    {
         Task<TEntity> Get<TEntity>();    
         Task Delete();
    }
