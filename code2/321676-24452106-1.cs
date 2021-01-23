    public static class HashSetExtentions
    {
        private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;
        public static HashSet<T> SetCapacity<T>(this HashSet<T> hs, int capacity)
        {
            var initialize = hs.GetType().GetMethod("Initialize", Flags);
            initialize.Invoke(hs, new object[] { capacity });
            return hs;
        }
        public static HashSet<T> GetHashSet<T>(int capacity)
        {
            return new HashSet<T>().SetCapacity(capacity);
        }
    }
