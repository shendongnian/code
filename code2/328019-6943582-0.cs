    public sealed class Singleton
    {
        IEnumerable<string> Values { get; set; }
    
        private Singleton()
        {
            Console.WriteLine("-- Private Singleton constructor");
            Values = new[] { "quick", "brown", "fox" };
        }
    
        public static Singleton Instance
        {
            get
            {
                Console.WriteLine("- Singleton Instance");
                return Nested.instance;
            }
        }
    
        public static void Initialize()
        {
            Console.WriteLine("- Singleton Initialize");
            Nested.Initialize();
        }
    
        internal class Nested
        {
            private static object syncRoot = new object();
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
                Console.WriteLine("-- Static Nested constructor");
            }
    
            internal static readonly Singleton instance = new Singleton();
    
            internal static void Initialize()
            {
                lock (syncRoot)
                {
                    Console.WriteLine("-- Locked");
                    Console.WriteLine("--- Nested Initialize");
                    Console.WriteLine("-- Unlocked");
                }
            }
        }
    }
