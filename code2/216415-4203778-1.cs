    public class Singleton<T1, T2>
    {
        private static Singleton<T1, T2> _instance = null;
        private static Object _mutex = new Object();
        private Singleton(T1 arg1, T2 arg2)
        {
            // whatever
        }
        public static Singleton<T1, T2> GetInstance(T1 arg1, T2 arg2)
        {
            if (_instance == null)
            {
                lock (_mutex) // now I can claim some form of thread safety...
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton<T1, T2>(arg1, arg2);
                    }
                }
            }
            return _instance;
        }
    }  
