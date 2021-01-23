    public sealed class Singleton
    {
        IEnumerable<string> Values {get; private set;}
        private Singleton()
        {
            Values = new[]{"quick", "brown", "fox"};
        }
    
        public static Singleton Instance { get { return Nested.instance; } }
    
        public static void Initialize() {
            Nested.Initialize();
        }
        private class Nested
        {
            internal static readonly Singleton instance;
            internal static object instanceLock = new object();
            public static void Initialize() {
                lock(instanceLock) {
                    instance = new Singleton();
                }
            }
        }
    } 
