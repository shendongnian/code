    public abstract class Singleton<ClassType> where ClassType : new()
    {
      static Singleton()
      {
      }
      private static readonly ClassType instance = new ClassType();
      public static ClassType Instance
      {
        get
        {
          return instance;
        }
      }
    }
