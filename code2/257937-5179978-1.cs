    public class Singleton
    {
        private static Singleton instance = new Singleton();
        public static Singleton Instance { get { return instance; } }
        // Only use this if you really need it - see the page for details
        static Singleton() {}
 
        private Singleton()
        {
            // I assume this logic varies
        }
    }
