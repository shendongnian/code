    public static class Stringifier
    {
        public static void Set<T>(Func<T, string> func)
        {
            StringifierInternal<T>.Stringify = func;
        }
        public static string Stringify<T>(T value)
        {
            return StringifierInternal<T>.Stringify(value);
        }
        private static class StringifierInternal<T>
        {
            public static Func<T, string> Stringify { get; set; }
        }
    }
