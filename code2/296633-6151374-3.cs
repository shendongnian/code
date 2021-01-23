    public partial class Window1 : Window,INotifyPropertyChanged 
    {
        public Window1()
        {
            Persons = new ObservableCollection<Person>();
            InitializeComponent();
            Persons.Add(new Person() { Name = "John 1", Age = 25, City = "New Delhi", Email = "abc@abc.com" });
            Persons.Add(new Person() { Name = "John 2", Age = 25, City = "New Delhi", Email = "abc@abc.com" });
            Persons.Add(new Person() { Name = "John 3", Age = 25, City = "New Delhi", Email = "abc@abc.com" });
            Persons.Add(new Person() { Name = "John 4   ", Age = 25, City = "New Delhi", Email = "abc@abc.com" });
           DataContext = this ;
        }
        private ObservableCollection<Person> persons;
        public ObservableCollection<Person> Persons {
            get
            {
                return persons;
            }
            set
            {
                persons = value;
                NotifyPropertyChanged("Persons");
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age  { get; set; }
        public string Email { get; set; }
    }
