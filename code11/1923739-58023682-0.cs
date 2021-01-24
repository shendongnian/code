     public class Singleton
        {
            private static string _locker = new object();
            private static Singleton _instance = null;
    
            public static Singleton Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (_locker)
                        {
                            if (_instance == null)
                            {
                                _instance = new Singleton();
                            }
                        }
                    }
                    return _instance;
                }
            }
        }
