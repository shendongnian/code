    var stuff = new ObservableCollection<string>();
    ClosureDelegate closure = (x) => {
        ListCollectionView result = new ListCollectionView(x);
        //Use this method to unsubscribe to events on the underlying collection and allow the CollectionView to be garbage collected.
        result.DetachFromSourceCollection();
    };
    
    while (true)
    {
        closure(stuff);
        GC.Collect(); 
    }
