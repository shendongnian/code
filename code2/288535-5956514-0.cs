    public class MyClass : INotifyPropertyChanged
    {
        private Network _network;
        public Network Network
        {
            get
            {
                return _network;
            }
            set
            {
                if (value != _network)
                {
                    _network = value;
                    NotifyPropertyChanged(value);
                }
            }
        }
        protected NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
