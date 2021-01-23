    [Serializable]
    public class SObservableCollection<T> : ObservableCollection<T>, 
        INotifyPropertyChanged
    {
        [field:NonSerialized]
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
    
        [field: NonSerialized]
        private PropertyChangedEventHandler _propertyChangedEventHandler;
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                _propertyChangedEventHandler = Delegate.Combine(_propertyChangedEventHandler, value) as PropertyChangedEventHandler;
            }
            remove
            {
                _propertyChangedEventHandler = Delegate.Remove(_propertyChangedEventHandler, value) as PropertyChangedEventHandler;
            }
        }
    
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = CollectionChanged;
    
            if (handler != null)
            {
                handler(this, e);
            }
        }
    
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = _propertyChangedEventHandler;
    
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
