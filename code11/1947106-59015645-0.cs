    public ObservableCollection<Image> _selectedImages { get; set; }
        public ObservableCollection<Image> SelectedImages
        {
            get { return _selectedImages; }
            set
            {
                _selectedImages = value;
                OnPropertyChanged();
            }
        }
