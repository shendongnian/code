    public MyViewModel()
    {
        MyItemsSource = new ObservableCollection<MyType>();
        MyItemsSource.CollectionChanged += MyItemsSource_CollectionChanged;
        MyItemsSource.Add(new MyType() { MyProperty = false });
        MyItemsSource.Add(new MyType() { MyProperty = true});
        MyItemsSource.Add(new MyType() { MyProperty = false });
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
