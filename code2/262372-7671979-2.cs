    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            PersonList = new ObservableCollection<Person>()
                             {
                                 new Person(){Name="Bobby"}
                              };
        }
        public ObservableCollection<Person> PersonList { get; set; }
        public void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Person : INotifyPropertyChanged
    {
        private string name;
    
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                   name = value;
                   OnPropertyChanged("Name");
                 }
           }
        }
        public void OnPropertyChanged(string p)
        {
           if (PropertyChanged != null)
           {
               PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
