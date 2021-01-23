     private ObservableCollection<Foo> _Collection;
     public ObservableCollection<Foo> Collection 
    { 
    get
    {
    return collection;
    }
     set
    {
    collection = value;
    OnPropertyChanged("Collection");
    }
