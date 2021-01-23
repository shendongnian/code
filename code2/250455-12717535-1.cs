    public class DiscardingStack<TObject> : IEnumerable<TObject>
    {
        private readonly int capacity;
        private readonly List<TObject> items;
        private int index = -1;
        public DiscardingStack(int capacity)
        {
            this.capacity = capacity;
            items = new List<TObject>(capacity);
        }
        public DiscardingStack(int capacity, IEnumerable<TObject> collection)
            : this(capacity)
        {
            foreach (var o in collection)
            {
                Push(o);
            }
        }
        public DiscardingStack(ICollection<TObject> collection)
            : this(collection.Count, collection)
        {
        }
        public void Clear()
        {
            if (items.Count >= 0)
            {
                items.Clear();
                index = items.Count - 1;
            }
        }
        public int Index
        {
            get { return index; }
            set
            {
                if (index >= 0 && index < items.Count)
                {
                    index = value;
                }
                else throw new InvalidOperationException();
            }
        }
        public int Count
        {
            get { return items.Count; }
        }
        public TObject Current
        {
            get { return items[index]; }
            set { index = items.IndexOf(value); }
        }
        public int Capacity
        {
            get { return capacity; }
        }
        public TObject Pop()
        {
            if (items.Count <= 0)
                throw new InvalidOperationException();
            
            var i = items.Count - 1;
            var removed = items[i];
            items.RemoveAt(i);
            if (index > i)
                index = i;
            return removed;
        }
        public void Push(TObject item)
        {
            if (index == capacity - 1)
            {
                items.RemoveAt(0);
                index--;
            }
            else if (index < items.Count - 1)
            {
                var removeAt = index + 1;
                var removeCount = items.Count - removeAt;
                items.RemoveRange(removeAt, removeCount);
            }
            items.Add(item);
            index = items.Count - 1;
        }
        public TObject Peek()
        {
            return items[items.Count-1];
        }
        public TObject this[int i]
        {
            get { return items[i]; }
        }
        public IEnumerator<TObject> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
