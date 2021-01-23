    public sealed class SingletonIdGenerator
    {
        private static long _id;
        private SingletonIdGenerator()
        {
        }
    
        public string Id
        {
            get { return _id++.ToString().Substring(8); }
        }
    
        public static SingletonIdGenerator Instance { get { return Nested.instance; } }
    
        private class Nested
        {
            static Nested()
            {
                _id = DateTime.Now.Ticks;
            }
            internal static readonly SingletonIdGenerator instance = new SingletonIdGenerator();
        }
    }
