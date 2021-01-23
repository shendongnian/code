    public class ObservableCollection : ICollection<object>,
        INotifyCollectionChanged
    {
        private ObservableCollection<object> _collection;
        public ObservableCollection()
        {
            _collection = new ObservableCollection<object>();
            _collection.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(collectionChanged);
        }
        public ObservableCollection(IEnumerable items)
        {
            if (null == items)
            {
                throw new ArgumentNullException("items");
            }
            _collection = new ObservableCollection<object>();
            foreach (object item in items)
            {
                Add(item);
            }
            _collection.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(collectionChanged);
        }
        ...stuff necessary to implement ICollection<object>...
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        void collectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = CollectionChanged;
            if (null != handler)
            {
                handler(this, e);
            }
        }
    }
