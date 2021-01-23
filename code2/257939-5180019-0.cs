    public class Singleton<T> where T : new()
    {
      private static T _Instance;
      private static readonly object _InstanceLock = new object();
      public static T Instance
      {
        get
        {
          if (_Instance == null)
          {
            lock (_InstanceLock)
            {
              if (_Instance == null)
              {
                _Instance = new T();
              }
            }
          }
          return _Instance;
        }
      }
    }
    public class Foo : Singleton<Foo>
    {
      public void Something()
      {
      }
    }
    public class Example
    {
      public static void Main()
      {
        Foo.Instance.Something();
      }
    }
