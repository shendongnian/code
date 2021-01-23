    public abstract class Singleton<T> where T : class, new()
    {
        private static readonly T _instance;
        public static T Instance { get { return _instance; } }
        public static Singleton() 
        {
            _instance = new T();
        }
    }
