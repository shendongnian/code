    Dictionary<string, object> _values;
    Dictionary<string, NotifyCollectionChangedEventHandler> _collectionChangedDelegates;
    void ClearDelegates()
    {
        foreach (var i in
            _values.Join(_collectionChangedDelegates,
                         outer => outer.Key,
                         inner => inner.Key,
                         (outer, inner) =>
                         new
                         {
                             Target = (INotifyCollectionChanged)outer.Value,
                             EventHandler = inner.Value
                         })) // expected, you manage your dictionaries carefully
            i.Target.CollectionChanged -= i.EventHandler;
        _collectionChangedDelegates.Clear();
    }
