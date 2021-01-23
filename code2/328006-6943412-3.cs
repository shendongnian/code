    public sealed class Singleton
    {
        IEnumerable<string> Values {get; private set;}
        private Singleton()
        {
            Values = new[]{"quick", "brown", "fox"};
        }
        public static Singleton Instance { get { return Nested.instance; } }
    
        private static object instanceLock = new object();
        private static bool isInitialized = false; 
        public static void Initialize() {
            lock(instanceLock) {
                if (!isInitialized) {
                    isInitialized = true;
                    Instance.Values = new[]{"another", "set", "of", "values"};
                }
            }
        }
        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
            internal static readonly Singleton instance = new Singleton(true);
        }
    } 
