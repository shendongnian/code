    private YourViewModelType ViewModel
    {
        get { return DataContext as YourViewModelType; }
    }
    private bool HasViewModel { get { return ViewModel != null; } }
