    public static class Expensive
    {
        private static readonly ConcurrentDictionary<int, int> _map = 
            new ConcurrentDictionary<int, int>();
    
        public static int Calculate(int n)
        {
            return _map.AddOrUpdate(n, Add, (key, value) => value);
        }
    
        static int Add(int key)
        {
            return 0;
        }
    }
