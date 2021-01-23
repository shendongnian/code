    public class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> m_persons;
        public ObservableCollection<Person> Persons
        {
            get
            {
                return m_persons;
            }
            set
            {
                m_persons = value;
                OnPropertyChanged("Persons");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
