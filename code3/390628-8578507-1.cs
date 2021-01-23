    class Example : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool OnPropertyChanging<T>(string propertyName, T originalValue, T newValue)
        {
            var handler = this.PropertyChanging;
            if (handler != null)
            {
                var args = new PropertyChangingCancelEventArgs<T>(propertyName, originalValue, newValue);
                handler(this, args);
                return !args.Cancel;
            }
            return true;
        }
        protected void OnPropertyChanged<T>(string propertyName, T previousValue, T currentValue)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs<T>(propertyName, previousValue, currentValue));
        }
        int _ExampleValue;
        public int ExampleValue
        {
            get { return _ExampleValue; }
            set
            {
                if (_ExampleValue != value)
                {
                    if (this.OnPropertyChanging("ExampleValue", _ExampleValue, value))
                    {
                        var previousValue = _ExampleValue;
                        _ExampleValue = value;
                        this.OnPropertyChanged("ExampleValue", previousValue, value);
                    }
                }
            }
        }
    }
