    public MyViewModel()
    {
        MyItemsSource = new TrulyObservableCollection<MyType>();
        MyItemsSource.CollectionChanged += MyItemsSource_CollectionChanged;
        MyItemsSource.Add(new MyType() { MyProperty = false });
        MyItemsSource.Add(new MyType() { MyProperty = true});
        MyItemsSource.Add(new MyType() { MyProperty = false });
    }
    void MyItemsSource_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
        // Handle here
    }
