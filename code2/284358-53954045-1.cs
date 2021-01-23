    public class FixedSizedQueue<T> : IReadOnlyCollection<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly object _lock = new object();
        public int Count { get { lock (_lock) { return _queue.Count; } } }
        public int Limit { get; }
        public FixedSizedQueue(int limit)
        {
            Limit = limit;
        }
        public void Enqueue(T obj)
        {
            lock (_lock)
            {
                _queue.Enqueue(obj);
                while (_queue.Count > Limit)
                    _queue.Dequeue();
            }
        }
        public void Clear()
        {
            lock (_lock)
                _queue.Clear();
        }
        public IEnumerator<T> GetEnumerator()
        {
            lock (_lock)
                return new List<T>(_queue).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
