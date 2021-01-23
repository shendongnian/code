    public class MyEntity : INotifyPropertyChanged
    {
        public bool MyFlag 
        {
            get { return _myFlag; }
            set 
            {
                _myFlag = value;
                OnPropertyChanged("MyFlag");
            }
        }
    
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
