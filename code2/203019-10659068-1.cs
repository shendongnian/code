    public static class List
    {
        public static IList<T> Empty<T>()
        {
            // Note that the static type is only instantiated when
            // it is needed, and only then is the T[0] object created, once.
            return EmptyArray<T>.Instance;
        }
        private sealed class EmptyArray<T>
        {
            public static readonly T[] Instance = new T[0];
        }
    }
