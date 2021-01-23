        var stuff = new ObservableCollection<string>();
        while (true)
        {
            ListCollectionView result = new ListCollectionView(stuff);
            //Use this method to unsubscribe to events on the underlying collection and allow the CollectionView to be garbage collected.
            result.DetachFromSourceCollection();
            //When finished set to null
            result = null;
            GC.Collect();
        }
