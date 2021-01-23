    int count4 = yourList.GetCount();  // uses the ICollection<T>.Count property
    int count5 = yourArray.GetCount();  // uses the ICollection<T>.Count property
    int count6 = yourEnumerable.GetCount();  // compile-time error
    // ...
    public static class CollectionExtensions
    {
        public static int GetCount<T>(this ICollection<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Count;
        }
        public static int GetCount(this ICollection source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Count;
        }
    }
