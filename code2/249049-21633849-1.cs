    class Parameter : INotifyPropertyChanged //wrapper
    {
        private string _Value;
        public string Value //real value
        {
            get { return _Value; }
            set { _Value = value; RaisePropertyChanged("Value"); } 
        }
        public Parameter(string value)
        {
            Value = value;
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
