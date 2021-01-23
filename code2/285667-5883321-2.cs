    class Sample : INotifyPropertyChanged
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FirstName"));
            }
        }
    
        #region Implementation of INotifyPropertyChanged
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    
        #endregion
    }
