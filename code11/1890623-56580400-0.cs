    private ICollectionView _myContents;
    public ICollectionView MyContents
    {
        get
        {
            return _myContents;
        }
        set
        {
            if (_myContents != value)
            {
                _myContents = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyContents)));
            }
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        if ((sender as DataGrid).DataContext is MyViewModel viewModel)
        {
            MyContents = viewModel.ContentsView();
        }
    }
