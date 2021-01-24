    internal ICollectionView ContentsView()
    {
        ObservableCollection<ObservableCollection<MyItemType>> groupedCollection = new ObservableCollection<ObservableCollection<MyItemType>>();
        
        // It doesn't matter how this grouped collection is filled...
        
        CollectionViewSource collectionViewSource = new CollectionViewSource();
        collectionViewSource.IsSourceGrouped = true;
        collectionViewSource.Source = groupedCollection;
        return collectionViewSource.View;
    }
