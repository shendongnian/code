    class SomeInterfaceCollection
    {
        private static class Item<T>
        {
            public static ISomeInterface<T> Value;
        }
        public static ISomeInterface<T> Get<T>()
        {
            return Item<T>.Value;
        }
        public static void Set<T>(ISomeInterface<T> value)
        {
            Item<T>.Value = value;
        }
    }
