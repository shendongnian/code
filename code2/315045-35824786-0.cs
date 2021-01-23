    public static class LinqExtensions
    {
        public static void DisposeItems<T>(this IEnumerable<T> source) where T : IDisposable
        {
            foreach(var item in source)
            {
                item.Dispose();
            }
        }
    }
