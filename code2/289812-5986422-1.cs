        private Visibility _isVisible = Visibility.Visible;
        public Visibility IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                RaisePropertyChanged("IsVisible");
            }
        }
        public RelayCommand MakeVisibleCommand
        {
            get
            {
                return new RelayCommand(() => IsVisible = Visibility.Collapsed);
            }
        }
