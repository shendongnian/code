    public sealed class NonConcurrentBag<T>: IReadOnlyCollection<T>
    {
        public void Add(T item)
        {
            // When adding an item, add it to a random location to avoid callers assuming an ordering.
            if (_items.Count == 0)
            {
                _items.Add(item);
                return;
            }
            int index = _rng.Next(0, _items.Count);
            _items.Add(_items[index]);
            _items[index] = item;
        }
        public void Clear()
        {
            _items.Clear();
        }
        public T Take()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Attempting to Take() from an empty NonConcurrentBag");
            var result = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);
            return result;
        }
        public bool IsEmpty => _items.Count == 0;
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Count => _items.Count;
        readonly List<T> _items = new List<T>();
        readonly Random _rng = new Random();
    }
