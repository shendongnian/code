    public interface IRepository<T> where T: class, IEntity
    {
      IEnumerable<T> GetAll();
    }
    
    public interface IEntity
    {
      // E.g.:
      long Id {get;}
    }
    
    public class Account : IEntity { ... }
    
    public class AccountRepository : IRepository<Account>
    {
      public IEnumerable<Account> GetAll()
      {
        // ... your stuff with SQL commands
      }
    }
