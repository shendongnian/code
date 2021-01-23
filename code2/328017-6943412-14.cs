    public sealed class Singleton
    {
        IEnumerable<string> Values {get; private set;}
        private Singleton()
        {
            Values = new[]{"quick", "brown", "fox"};
        }
    
        private static Singleton instance;
        private static object instanceLock = new object();
        public static Singleton Instance {
            get {
                Initialize();
                return instance;
            }
         }
    
        public static void Initialize() {
            if (instance == null) {
                lock(instanceLock) {
                    if (instance == null)
                        instance = new Singleton();
                }
            }
        }
    } 
