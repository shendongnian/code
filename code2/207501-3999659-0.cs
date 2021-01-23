    static class Extensions
    {
        public IEnumerable<int> Select(this IEnumerable<int> items, Func<int, bool> selector)
        {
            C.list.Add(selector);
            return System.Enumerable.Select(items, selector);
        }
    }
            
    class C
    {
        public static List<Func<int, bool>> list = new List<Func<int, bool>>();
        public static void M()
        { 
            int[] primaries = { 10, 20, 30}; 
            int[] secondaries = { 11, 21, 30}; 
            foreach (int primary in primaries) 
            {
                var primaryApps = secondaries.Select(x => x == primary);
                // do something with primaryApps
            }
            C.N();
        }
        public static void N()
        {
            Console.WriteLine(C.list[0](10)); // true or false?
        }
    }
                
