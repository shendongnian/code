    public class FixedSizeObservableCollection<T> : ObservableCollection<T>
    {
        private readonly int maxSize;
        public FixedSizeObservableCollection(int maxSize)
        {
            this.maxSize = maxSize;
        }
        protected override void InsertItem(int index, T item)
        {
            if (Count == maxSize)
                return; // or throw exception
            base.InsertItem(index, item);
        }
    }
