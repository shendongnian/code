    public class ThreadSafeEnumerator<T>
    {
        private readonly IList<T> _list;
        private readonly List<int> _indexes;
        private readonly object _locker = new object();
        private int _currentIndex;
        public ThreadSafeEnumerator(IList<T> list)
        {
            _list = list;
            _indexes = Enumerable.Range(0, list.Count).ToList();
            _currentIndex = list.Count;
        }
        public bool MoveNext(out Removable current)
        {
            current = default;
            T item;
            int i;
            lock (_locker)
            {
                _currentIndex--;
                i = _currentIndex;
                if (i < 0) return false;
                item = _list[i];
            }
            current = new Removable(item, () =>
            {
                lock (_locker)
                {
                    var index = _indexes.BinarySearch(i);
                    _indexes.RemoveAt(index);
                    _list.RemoveAt(index);
                }
            });
            return true;
        }
        public struct Removable
        {
            public T Value { get; }
            private readonly Action _action;
            public Removable(T value, Action action)
            {
                Value = value;
                _action = action;
            }
            public void Remove() => _action();
        }
    }
