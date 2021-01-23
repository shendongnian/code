     public class MySingleton
     {
          protected static Lazy<MySingleton> _instance = new Lazy<MySingleton>(() => new MySingleton());
          protected MySingleton() {}
          public static MySingleton Instance
          {
              get { return _instance.Value; }
          }
     }
