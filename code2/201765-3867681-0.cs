    class UniquePattern<T> where T : new(int)
    {
        private static Dictionary<int, T> idLookup;
        ....
        private T(id) {...}
        public static T Get(id) 
        {
           ...
        }
    }
