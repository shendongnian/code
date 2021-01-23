    public class SomeSingleton
    {
       private Dependency someDependency;
       private static SomeSingleton instance;
       public static SomeSingleton Instance
       {
          return instance ?? (instance = new SomeSingleton());
       }
       static SomeSingleton() {}
       private SomeSingleton() : this(new Dependency()) {}
       protected SomeSingleton(Dependency someDependency)
       {
          this.someDependency = someDependency;
       }
    }
