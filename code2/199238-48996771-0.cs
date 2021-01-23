    public class ObservableDictonary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private readonly Dictionary<TKey, int> _keyIndexes = new Dictionary<TKey, int>();
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public new void Add(TKey key, TValue value)
        {
            _keyIndexes.Add(key, _keyIndexes.Count);
            base.Add(key, value);
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(Values));
            OnCollectionChanged(NotifyCollectionChangedAction.Add, value);
        }
        public void AddRange(params KeyValuePair<TKey, TValue>[] values)
        {
            foreach (var i in values)
            {
                base.Add(i.Key, i.Value);
                _keyIndexes.Add(i.Key, _keyIndexes.Count);
            }
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(Values));
            OnCollectionChanged(NotifyCollectionChangedAction.Add, values.ToList());
        }
        public new void Remove(TKey key)
        {
            if (!TryGetValue(key, out var value)) return;
            var index = _keyIndexes[key];
            _keyIndexes.Remove(key);
            base.Remove(key);
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(Values));
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, value, index);
        }
        public new void Clear()
        {
            
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        private void OnCollectionChanged(NotifyCollectionChangedAction action, object item)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item));
        }
        private void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index));
        }
    }
