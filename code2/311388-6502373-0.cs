    public class MyCollection<T> : Collection<T>
    {
        private readonly object syncRoot = new object();
        protected override void SetItem(int index, T item)
        {
            lock (syncRoot)
                base.SetItem(index, item);
        }
        protected override void InsertItem(int index, T item)
        {
            lock (syncRoot)
                base.InsertItem(index, item);
        }
        protected override void ClearItems()
        {
            lock (syncRoot)
                base.ClearItems();
        }
        protected override void RemoveItem(int index)
        {
            lock (syncRoot)
                base.RemoveItem(index);
        }
        public new int Count(Func<T, bool> predicate)
        {
            lock (syncRoot)
                return Enumerable.Count(this, predicate);
        }
    }
