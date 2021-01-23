    public static class EnumerableExtensions
    {
        public static ReadOnlyEnumerable<T> AsReadOnly<T>(
             this IEnumerable<T> source)
        {
            return new ReadOnlyEnumerable<T>(source);
        }
    }
    public sealed class ReadOnlyEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _source;
        public ReadOnlyEnumerable(IEnumerable<T> source)
        {
            if (_source == null)
            {
                throw new ArgumentNullException("source");
            }
            _source = source;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _source.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _source.GetEnumerator();
        }
    }
    public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count) 
    { 
        if (source == null) throw new ArgumentNullException("source"); 
        if (count < 0) throw new ArgumentOutOfRangeException("count"); 
 
        if (count == 0) 
           return Enumerable.Empty<T>();
 
        var queue = new Queue<T>(count); 
 
        foreach (var t in source) 
        { 
            if (queue.Count == count) queue.Dequeue(); 
 
            queue.Enqueue(t); 
        } 
 
        return queue.AsReadOnly(); 
    } 
