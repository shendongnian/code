    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }        
        } 
        private string _myValue;
        public string MyValue
        {
            get { return _myValue; }
            set
            {
                _myValue = value;
                OnPropertyChanged("MyValue");
            }
        }
    }
