    var list = new ObservableCollection<int>();
    using (var o = Observable
        .FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(h => list.CollectionChanged += h, h => list.CollectionChanged -= h)
        .Subscribe(e => Console.WriteLine($"{e.EventArgs.Action} {e.EventArgs.NewItems[0]}")))
    {
        list.Add(1);
        list.Add(10);
    }
    
    // Add 1
    // Add 10
