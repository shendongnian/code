    public class Item : INotifyPropertyChanged
    {
        private List<string> _MaterializedPropertiesInternal;
        private List<string> MaterializedPropertiesInternal
        {
            get
            {
                if (_MaterializedPropertiesInternal==null) 
                    _MaterializedPropertiesInternal = new List<string>();
                return _MaterializedPropertiesInternal;
            }
        }
        private ReadOnlyCollection<string> _MaterializedProperties;
        public IEnumerable<string> MaterializedProperties
        {
            get 
            {
                if (_MaterializedProperties==null) _MaterializedProperties = 
                  new ReadOnlyCollection<string>(MaterializedPropertiesInternal);
                return _MaterializedProperties;
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
            if(PropertyChanged != null) PropertyChanged(this, 
              new PropertyChangedEventArgs(propertyName));
            MaterializedPropertiesInternal.Add(propertyName);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
