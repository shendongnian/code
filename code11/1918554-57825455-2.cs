    public class ConcurrentList<T> : IEnumerable<T>
    {
        private readonly List<T> _list;
        private readonly ReaderWriterLock _lock = new ReaderWriterLock();
        public ConcurrentList()
        {
            _list = new List<T>();
        }
        public ConcurrentList(IEnumerable<T> collection)
        {
            _list = new List<T>(collection);
        }
        public int Count => ReadSafe(list => list.Count);
        public T this[int index]
        {
            get => ReadSafe(list => list[index]);
            set => WriteSafe(list => list[index] = value);
        }
        public IEnumerable<(int Index, T Value)> GetRange(int from, int to)
        {
            using (new DisposableReader(_lock))
            {
                for (int i = from; i < to; i++)
                {
                    yield return (i, _list[i]);
                }
            }
        }
        public void Add(T item) => WriteSafe(list => list.Add(item));
        public void AddRange(IEnumerable<T> r) => WriteSafe(list => list.AddRange(r));
        public void Clear() => WriteSafe(list => list.Clear());
        public void UpdateRange(IEnumerable<(int Index, T Value)> changes)
        {
            WriteSafe(list =>
            {
                foreach (var change in changes)
                {
                    list[change.Index] = change.Value;
                }
            });
        }
        public IEnumerator<T> GetEnumerator()
        {
            using (new DisposableReader(_lock))
            {
                foreach (var item in _list)
                {
                    yield return item;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public TResult ReadSafe<TResult>(Func<List<T>, TResult> function)
        {
            _lock.AcquireReaderLock(Timeout.Infinite);
            try
            {
                return function(_list);
            }
            finally
            {
                _lock.ReleaseReaderLock();
            }
        }
        public void WriteSafe(Action<List<T>> action)
        {
            _lock.AcquireWriterLock(Timeout.Infinite);
            try
            {
                action(_list);
            }
            finally
            {
                _lock.ReleaseWriterLock();
            }
        }
        private struct DisposableReader : IDisposable
        {
            private readonly ReaderWriterLock _lock;
            public DisposableReader(ReaderWriterLock obj)
            {
                _lock = obj;
                _lock.AcquireReaderLock(Timeout.Infinite);
            }
            public void Dispose() => _lock.ReleaseReaderLock();
        }
    }
