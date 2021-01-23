    ObservableCollection<Foo> collection = new ObservableCollection<Foo>();
    ICollectionView view = CollectionViewSource.GetDefaultView();
    view.Filter = YourFilterMethod;
    // Fill the collection
    collection.Add(...);
