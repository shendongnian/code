        public bool MyProperty
        {
            get { return IsAProperty(); }
        }
        
        public bool IsAProperty()
        {
            return _myvalue + 1 == 4;
        }
        public void SetValue(int value)
        {
            _myvalue = value;
            NotifyPropertyChanged(MyProperty);
        }
