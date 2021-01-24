    public class Friend : INotifyPropertyChanged
    {
        //Properties
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                Changed(nameof(LastName));
            }
        }
        //Implementation: INotifyPropertyChanged
        private void Changed(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
