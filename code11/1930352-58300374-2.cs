    var list = new ObservableCollection<Product>();
    using (var o = Observable
        .FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(h => list.CollectionChanged += h, h => list.CollectionChanged -= h)
        .Subscribe(e => Console.WriteLine($"{e.EventArgs.Action} {e.EventArgs.NewItems[0]}")))
    {
        list.Add(productSample1);
        list.Add(productSample2);
    }
    
    // Add 1
    // Add 10
