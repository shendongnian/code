    public class BoundedList<T> : Collection<T> {
        public int MaxSize { get; private set; }
        public BoundedList(int MaxSize) : base(new List<T>(maxSize)) {
            MaxSize = maxSize;
        }
        protected override void InsertItem(T item, int index) {
            base.InsertItem(item, index)
            if (Count > MaxSize)
                Remove(0);
        }
    }
