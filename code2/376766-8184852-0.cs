    public class CustomObject : INotifyPropertyChanged
    {
        private string _client;
        public string Client
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged("Client");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
