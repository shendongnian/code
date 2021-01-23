    public sealed class Singleton
    {
        static Singleton instance=null;
        static lockObject = new object();
        Singleton()
        {
        }
    
        public static Singleton Instance
        {
            get
            {
                lock(lockObject)
                {
                   if (instance==null)
                   {
                       instance = new Singleton();
                   }
                }
                return instance;
            }
        }
    }
