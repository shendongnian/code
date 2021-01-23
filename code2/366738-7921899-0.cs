    public static class Extensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this T item)
        {
             yield return item;
        }
    }
