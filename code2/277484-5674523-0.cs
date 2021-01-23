    public class Singleton
    {
        private static object _syncRoot = new object();
    
        public Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance != null)
                           return _instance;
    
                        _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }
    
        private Singleton() { }
        private static Singleton _instance;
    }
