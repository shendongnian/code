        Color currentColor;
        public Color CurrentColor
        {
            get { return currentColor; }
            set { currentColor = value; OnPropertyChanged("CurrentColor"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
