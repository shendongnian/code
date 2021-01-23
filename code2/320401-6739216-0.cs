    class SomeInterfaceCollection
    {
        private static class Item<T>
        {
            public static ISomeInterface<T> Value;
        }
        public ISomeInterface<T> Get<T>()
        {
            return Item<T>.Value;
        }
        public void Set<T>(ISomeInterface<T> value)
        {
            Item<T>.Value = value;
        }
    }
