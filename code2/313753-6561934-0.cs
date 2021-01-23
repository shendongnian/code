    public class Class_RetrieveCommand : INotifyPropertyChanged
    {
        private string _CMD;
        public string CMD 
        {
            get { return _CMD; } 
            set { _CMD = value; OnPropertyChanged("CMD"); }
        }
        ... similar for the other properties
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
