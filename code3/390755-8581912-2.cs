    public class RepositoryFactory
    {
      IRepository<T> GetRepository<T>()
    {
      if (config == production) 
         return new Repository<T>(); // this is implemented with DB access through EF
      if (config == test)
         return new TestRepository<T>(); // this is implemented with test values without DB access
    }
    }
