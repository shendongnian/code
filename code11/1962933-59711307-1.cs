    Prices.CollectionChanged += (s, e) => 
    {
        // Subscribing on property changed event for newly added prices
        if (e.Action == NotifyCollectionChangedAction.Add)
            foreach (Price item in e.NewItems)
                item.PropertyChanged += WCFCallHandler;
        // Unsubscribing from property changed event of removed prices 
        if (e.Action == NotifyCollectionChangedAction.Remove)
            foreach (Price item in e.OldItems)
                item.PropertyChanged -= WCFCallHandler;
    };
