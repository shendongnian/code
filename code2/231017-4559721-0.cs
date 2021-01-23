    public sealed class Singleton
    {
       private Singleton() { }
       static Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());
    
       public static Singleton Instance
          {
              get
              {
                  return instance.Value;
              }
          }
    }
