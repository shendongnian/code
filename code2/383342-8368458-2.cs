    public sealed class Info
    {
        private static Info _instance;
        private static readonly object _lock = new object();
    
        // Private to disallow instantiation.
        private Info()
        {
        }
    
        public static Info Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance==null)
                    {
                        _instance = new Info();
                    }
                    return _instance;
                }
            }
        }
    }
