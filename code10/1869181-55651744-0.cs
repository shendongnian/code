    public class ObservableCollectionWrapper<T> : ICollection<T>, INotifyCollectionChanged
    {
        private readonly ObservableCollection<T> _collection;
        private readonly Dispatcher _dispatcher;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public ObservableCollectionWrapper(ObservableCollection<T> collection, Dispatcher dispatcher)
        {
            _collection = collection;
            _dispatcher = dispatcher;
            collection.CollectionChanged += Internal_CollectionChanged;
        }
        private void Internal_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _dispatcher.Invoke(() =>
            {
                this.CollectionChanged?.Invoke(sender, e);
            });
        }
        public int Count => _collection.Count;
        /* Implement the rest of the ICollection<T> interface */
    }
