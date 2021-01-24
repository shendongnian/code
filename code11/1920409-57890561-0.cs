    public ListView()
    {
        this.Student = new ObservableCollection();
        InitializeComponent();
        this.DataContext = this;
    
        // And here you actually add your items to the collection
    
        this.Student.Add(new IDictionary<string, object>("Key01", MyObject));
    }
