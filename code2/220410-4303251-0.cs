    public class MyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Whatever> _myCollection;
        private void NotifyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public ObservableCollection<Whatever> MyCollection
        {
            get
            {
                return _myCollection;
            }
            set
            {
                if (!ReferenceEquals(_myCollection, value))
                {
                    _myCollection = value;
                    NotifyChanged("MyCollection");
                }
            }
        }
    }
