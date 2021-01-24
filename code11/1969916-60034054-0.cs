    public ObservableCollection<string> Data source { get; set; }
    ICommand ApplyFilterCommand => new RelayCommand(FilterCollectionView);
    private void FilterCollectionView(object param)
    {  
      CollectionView collectionView = (param as CollectionViewSource).View;
      collectionView.Filter = item => item.StartsWith("a");
      collectionView.Refresh();
    }  
