    public Series()
    {
    	_dropPhotosSeries = new ObservableCollection<DropPhoto>();
    	_dropPhotosSeries.CollectionChanged += _dropPhotosSeries_CollectionChanged;
    }
    
    private void _dropPhotosSeries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
    	OnPropertyChanged(new PropertyChangedEventArgs(nameof(CanDrawPlot)));
    }
