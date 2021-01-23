    
    // should raise INotityPropertyChange.PropertyChanged
    public ObservableCollection<Entity> MyCollection { get; set; }
    
    MyCollection = new ObservableCollection<Entity>(ctx.EntitySet)); 
    ICollectionView view = CollectionViewSource.GetDefaultView(MyCollection);
    view.Filter = SomeFilteringFunction;
