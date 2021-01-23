    public sealed class Singleton
    {
        IEnumerable<string> Values {get; private set;}
        private Singleton(bool loadDefaults)
        {
            if (loadDefaults)
                Values = new[]{"quick", "brown", "fox"};
            else
                Values = new[]{"another", "set", "of", "values"};
        }
    
        public static Singleton Instance { get { return Nested.instance; } }
    
        public static void Initialize() {
            Nested.Initialize();
        }
        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
            internal static readonly Singleton instance = new Singleton(true);
            private static object instanceLock = new object();
            private static bool isInitialized = false; 
            public static void Initialize() {
                lock(instanceLock) {
                    if (!isInitialized) {
                        isInitialized = true;
                        instance = new Singleton(false);
                    }
                }
            }
        }
    } 
