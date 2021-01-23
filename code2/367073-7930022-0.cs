    [Import]
    public ConnectionStringSetupViewModel ViewModel
    {
        get { return DataContext as ConnectionStringSetupViewModel; }
        set { DataContext = value; }
    }
