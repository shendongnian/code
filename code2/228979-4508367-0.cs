    public class Person : INotifyPropertyChanged 
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; NotifyPropertyChanged("FirstName"); }
        }
       
        private string _greeting;
        public string Greeting
        {
            get { return _greeting; }
            set { _greeting = value; NotifyPropertyChanged("Greeting");  }
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
