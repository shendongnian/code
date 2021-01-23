    public static class HashSetExtensions
    {
        private static class HashSetDelegateHolder<T>
        {
            private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;
            public static MethodInfo InitializeMethod { get; } = typeof(HashSet<T>).GetMethod("Initialize", Flags);
        }
        public static HashSet<T> SetCapacity<T>(this HashSet<T> hs, int capacity)
        {
            HashSetDelegateHolder<T>.InitializeMethod.Invoke(hs, new object[] { capacity });
            return hs;
        }
        public static HashSet<T> GetHashSet<T>(int capacity)
        {
            return new HashSet<T>().SetCapacity(capacity);
        }
    }
