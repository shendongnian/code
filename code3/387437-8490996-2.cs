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
        // Handle here
    }
