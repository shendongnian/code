    public class Singleton
    {
        private static Singleton _default;
    
        public static Singleton Default
        {
            get
            {
                if (_default == null)
                    _default = new Singleton();
                return _default;
            }
        }
    
        private Singleton()
        { }
    
        public void SomeMethod()
        {
            // Do something...
        }
    }
