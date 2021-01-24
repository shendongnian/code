    public class ObservableItemCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        // Call this from the constructor
        private void InitialiseItems()
        {
            CollectionChanged += ContentCollectionChanged;
            foreach (T item in Items)
                item.PropertyChanged += ReplaceElementWithItself;
        }
        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (T item in e.OldItems)
                {
                    item.PropertyChanged -= ReplaceElementWithItself;
                }
            }
            if (e.NewItems != null)
            {
                foreach (T item in e.NewItems)
                {
                    item.PropertyChanged += ReplaceElementWithItself;
                }
            }
        }
        private void ReplaceElementWithItself(object sender, PropertyChangedEventArgs e)
        {
            var collectionChangedArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, IndexOf((T)sender));
            // Call this on the main thread
            OnCollectionChanged(collectionChangedArgs);
        }
    }
