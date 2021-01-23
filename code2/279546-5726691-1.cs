    public class RepositoryFactory : IRepositoryFactory
    {
       protected DataContext DataContext;
       public RepositoryFactory(IDataContextProvider provider)
       {
          DataContext = dataContextProvider.DataContext;
       }
    
       public IRepository<T> GetRepository<T>()
       {
          return new Repository<T>(DataContext);
       }
    }
    
    public class SimpleService : ISimpleService {
         public SimpleService(IRepositoryFactory factory) {
             ....
         }
    }
    
