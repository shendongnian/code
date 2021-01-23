    public static class IEnumerableExt
    {
        // usage: someObject.AsEnumerable();
        public static IEnumerable<T> AsEnumerable<T>(this T item)
        {
            yield return item; 
        }
    }
