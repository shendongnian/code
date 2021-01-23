    public static class Cached<T> where T : class, new()
    {
        private static T _cachedInstance;
        public static T Instance
        {
            get { return _cachedInstance ?? (_cachedInstance = new T()); }
        }
    }
    public static class Extensions
    {
        public static void Example()
        {
            Cached<B>.Instance.Foo();
        }
        public static void Foo<T>(this T thing) where T : A, new()
        {
            Console.WriteLine("Called from " + typeof(T).Name);
        }
    }
