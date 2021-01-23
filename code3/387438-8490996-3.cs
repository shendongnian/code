    public MyViewModel()
    {
        MyItemsSource = new TrulyObservableCollection<MyType>()
        { 
            new MyType() { MyProperty = false },
            new MyType() { MyProperty = true },
            new MyType() { MyProperty = false }
        };
        MyItemsSource.CollectionChanged += MyItemsSource_CollectionChanged;
    }
    
    void MyItemsSource_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
            foreach(MyType item in e.NewItems)
                item.PropertyChanged += MyType_PropertyChanged;
    
        if (e.OldItems != null)
            foreach(MyType item in e.OldItems)
                item.PropertyChanged -= MyType_PropertyChanged;
    }
    
    void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "MyProperty")
            DoWork();
    }
