    public MyMasterDetailPage()
    {
        InitializeComponent();
    
        // ...
    
        ContentLayout.Children.Add(new ItemsPage().Content);
        ContentLayout.BindingContext = new ItemsViewModel();
    }
