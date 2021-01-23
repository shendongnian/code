    public class FactoryRepository<T>
    {
      IDictionary<string, Func<T>> factoryCache;
       
      public FactoryRepository()
      {
          this.factoryCache = new Dictionary<string, Func<T>>();
      }
    }
