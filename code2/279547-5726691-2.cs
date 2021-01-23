    public class RepositoryFactory : IRepositoryFactory
    {
       protected DataContext dataContext;
       public RepositoryFactory(IDataContextProvider provider)
       {
          dataContext = dataContextProvider.DataContext;
       }
    
       public IRepository<T> GetRepository<T>()
       {
          return new Repository<T>(dataContext);
       }
    }
    
    public class SimpleService : ISimpleService {
         public SimpleService(IRepositoryFactory factory) {
             ....
         }
    }
    
