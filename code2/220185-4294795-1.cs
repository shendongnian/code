    namespace IEnumerableExtensions
    {
        public static class IEnumerableExtensions
        {
            public static void ForEach<T>(this IEnumerable<T> xs, Action<T> f)
            {
                foreach (var x in xs) f(x);
            }
        }
    }
