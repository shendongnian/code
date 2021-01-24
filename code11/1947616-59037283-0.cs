    public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public double ScreenOffset
        {
            get
            {
                return _screenOffset;
            }
            set
            {
                if (_screenOffset != value)
                {
                    _screenOffset = value;
                    NotifyPropertyChanged();
                }
            }
        }
