        public class ObservableCollectionCopy<T> : ObservableCollection<T>
        {
        public ObservableCollectionCopy(T firstItem, ObservableCollection<T> baseItems)
        {
            this.FirstItem = firstItem;
            this.Add(firstItem);
            foreach (var item in baseItems)
                this.Add(item);
            baseItems.CollectionChanged += BaseCollectionChanged;
        }
    
        public T FirstItem { get; set; }
    
        private void BaseCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (var newItem in e.NewItems.Cast<T>().Reverse())
                    this.Insert(e.NewStartingIndex + 1, newItem);
            if (e.OldItems != null)
                foreach (var oldItem in e.OldItems.Cast<T>())
                    this.Remove(oldItem);
        }
        }
