    class ObsCollection<T> : ObservableCollection<T>
        {
            public void UpdateCollection()
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Reset));
            }
        }
