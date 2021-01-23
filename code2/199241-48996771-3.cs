        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            if (!TryGetValue(key, out _)) return;
            var index = Keys.Count;
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(Values));
            OnCollectionChanged(NotifyCollectionChangedAction.Add, value, index);
        }
        public new void Remove(TKey key)
        {
            if (!TryGetValue(key, out var value)) return;
            var index = IndexOf(Keys, key);
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(Values));
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, value, index);
            base.Remove(key);
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
        private int IndexOf(KeyCollection keys, TKey key)
        {
            var index = 0;
            foreach (var k in keys)
            {
                if (Equals(k, key))
                    return index;
                index++;
            }
            return -1;
        }
    }
