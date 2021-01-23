    public interface IMyRepository<T>
    {
    }
    
    public class Repository<T> : IMyRepository<T>
    {
    }
    
    
    private IMyRepository<TEntity> CreateStubRepository<TEntity>()
    {
         return new Repository<TEntity>();
    }
    var repos = CreateStubRepository<User>();
