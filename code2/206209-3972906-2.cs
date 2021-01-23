    private void NotifyCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        lock (CollectionChanged)
        {
            if (CollectionChanged != null)
                Dispatcher.BeginInvoke(new Action(() => CollectionChanged(this, e)));
        }
    }
