    class Item : INotifyPropertyChanged
    {
        private List<string> _MaterializedProperties;
        public IEnumerable<string> MaterializedProperties
        {
            get
            {
                return new ReadOnlyCollection<string>(_MaterializedProperties);
            }
        }
        private int _MyProperty;
        public int MyProperty
        {
            get { return _MyProperty; }
            set
            {
                _MyProperty = value;
                OnPropertyChanged("MyProperty");                
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (_MaterializedProperties == null) _MaterializedProperties =
                new List<string>();
            _MaterializedProperties.Add(propertyName);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
