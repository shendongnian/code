    public MyMasterDetailPage()
    {
        InitializeComponent();
    
        // ...
    
        var itemsPage = new ItemsPage();
        ContentLayout.Children.Add(itemsPage.Content);
        
        var viewModel = new ItemsViewModel();
        ContentLayout.BindingContext = viewModel;
        itemsPage.viewModel = viewModel;
    }
