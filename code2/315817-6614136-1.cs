    public static class Extensions
    {
        public static EnumerableWrapper<T> Wrap<T>(this IEnumerable<T> source)
        {
            return new EnumerableWrapper<T>(source);
        }
    }
    public class EnumerableWrapper<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> source;
        public EnumerableWrapper(IEnumerable<T> source)
        {
            this.source = source;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorWrapper<T>(source.GetEnumerator());
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class EnumeratorWrapper<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> source;
        public EnumeratorWrapper(IEnumerator<T> source)
        {
            this.source = source;
        }
        public T Current { get { return source.Current; } }
        object IEnumerator.Current { get { return Current; } }
        public bool MoveNext()
        {
            return source.MoveNext();
        }
        public void Reset()
        {
            source.Reset();
        }
        
        public void Dispose()
        {
            source.Dispose();
        }
    }
