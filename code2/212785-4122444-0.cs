    class YourClass : INotifyPropertyChanged
    {
    
        private int _number;
        public int Number
        {
            get { return _number; }
            private set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
