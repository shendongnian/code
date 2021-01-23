    public class MySingleton
    {
       [ThreadStatic]
       private static MySingletonClass _instance = new MySingletonClass();
       public static MySingletonClass Instance { get { return _instance; } }
    }
