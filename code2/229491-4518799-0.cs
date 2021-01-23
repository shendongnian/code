    class Item : INotifyPropertyChanged
    {
        private List<string> _MaterializedObjects;
        public IEnumerable<string> MaterializedObjects
        {
            get
            {
                return new ReadOnlyCollection<string>(_MaterializedObjects);
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
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (_MaterializedObjects == null) _MaterializedObjects =
              new List<string>();
            _MaterializedObjects.Add(propertyName);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
