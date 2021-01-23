    public static class MySingleton 
    {
        private static Mutex instanceLock = new Mutex();
    
        private static MySingleton instance;
        public static MySingleton Instance
        {
            get
            {
                instanceLock.WaitOne();
                if(instance == null)
                {
                    instance = new MySingleton();
                }
                instanceLock.ReleaseMutex();
                return instance;
             }
        }
    
        private MySingleton()
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Initialize
        }
    }
    
    public class MyOtherClass
    {
        private MySingleton singleton = MySingleton.Instance;
    }
