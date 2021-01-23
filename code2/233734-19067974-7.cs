    public static IReadOnlyCollection<T> Materialize<T>(this IEnumerable<T> source)
    {
        // Null check...
        switch (source)
        {
            case ICollection<T> collection:
                return new ReadOnlyCollectionAdapter<T>(collection);
            case IReadOnlyCollection<T> readOnlyCollection:
                return readOnlyCollection;
            default:
                return source.ToList();
        }
    }
    public class ReadOnlyCollectionAdapter<T> : IReadOnlyCollection<T>
    {
        readonly ICollection<T> m_source;
        public ReadOnlyCollectionAdapter(ICollection<T> source) => m_source = source;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => m_source.Count;
        public IEnumerator<T> GetEnumerator() => m_source.GetEnumerator();
    }
