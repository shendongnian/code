       <ListBox ItemsSource="{Binding Path=Images}" SelectedItem="{Binding CurrentItem}" />
    private IndexedImage _currentItem;
    public IndexedImage CurrentItem
    {
        get { return _currentItem; }
        set
        {
            if (_currentItem == value) return;
            _currentItem = value;
            RaisePropertyChanged("CurrentItem");
        }
    }
        private ObservableCollection<IndexedImage> _images;
        public ObservableCollection<IndexedImage> Images
        {
            get { return _images ?? (_images = new ObservableCollection<IndexedImage>()); }
            set
            {
                if (_images == value) return;
                _images = value;
                RaisePropertyChanged("Images");
            }
        }
