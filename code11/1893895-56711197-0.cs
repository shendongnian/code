    public class BoundedSortedList<TKey, TValue> : SortedList<TKey, TValue>
    {
        private readonly int _boundedCapacity;
        private readonly List<TKey> _queue = new List<TKey>();
        public BoundedSortedList(int boundedCapacity)
        {
            _boundedCapacity = boundedCapacity;
        }
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            _queue.Add(key);
            if (this.Count > _boundedCapacity)
            {
                var keyToRemove = _queue[0];
                this.Remove(keyToRemove);
            }
        }
        public new TValue this[TKey key]
        {
            get { return base[key]; }
            set { this.Remove(key); this.Add(key, value); }
        }
        public new bool Remove(TKey key) { _queue.Remove(key); return base.Remove(key); }
        public new bool RemoveAt(int index) => throw new NotImplementedException();
        public new void Clear() { base.Clear(); _queue.Clear(); }
    }
