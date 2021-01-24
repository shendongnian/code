    public static class MySingleton
    {
        public static BaseModule _Module;
        
        public static BaseModule Module
        {
            get
            {
                return _Module;
            }
        }
        
        public static void ChangeImplementation (BaseModule module)
        {
            // do your checks here
            
            _Module = module;
        }
    }
