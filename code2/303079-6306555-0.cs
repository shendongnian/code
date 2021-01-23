    public class MyCollection<T> : Collection<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public MyCollection(Collection<T> list)
            : base(list)
        {
        }
    
        public MyCollection()
            : base()
        {
        }
    
        #region INotifyCollectionChanged Members
    
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    
        protected void NotifyChanged(NotifyCollectionChangedEventArgs args)
        {
            NotifyCollectionChangedEventHandler handler = CollectionChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        #endregion
    
        public new void Add(T item)
        {
            // Do some additional processing here!
        
            base.Add(item);
            this.NotifyChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, base.Count-1));
            this.OnPropertyChanged("Count");
        }
    }
