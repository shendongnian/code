    public sealed class Singleton
    {
        IEnumerable<string> Values {get; private set;}
        private Singleton()
        {
            Values = new[]{"quick", "brown", "fox"};
        }
    
        public static Singleton Instance {
            get {
                Nested.Initialize();
                return Nested.instance;
            }
         }
    
        public static void Initialize() {
            Nested.Initialize();
        }
        private class Nested
        {
            internal static readonly Singleton instance;
            private static object instanceLock = new object();
            private static bool isInitialized = false; 
            public static void Initialize() {
                lock(instanceLock) {
                    if (!isInitialized) {
                        isInitialized = true;
                        instance = new Singleton();
                    }
                }
            }
        }
    } 
