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
            return source.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
