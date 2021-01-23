    public class FactoryRepository<T>
    {
      IDictionary<string, Func<T>> factoryCache;
       
      public FactoryRepository()
      {
          this.factoryCache = new Dictionary<string, Func<T>>();
      }
      public void AddFactory(string key, Func<T> factory)
      {   
          this.factoryCache.Add(key, factory);
      }
    }
