    public class MainWindowViewModel : BaseViewModel
    {
        private RelayCommand ellipseCommand;
        public RelayCommand EllipseCommand
        {
            get
            {
                return ellipseCommand
                ?? (ellipseCommand = new RelayCommand(
                  () =>
                 {
                     Console.WriteLine("CIRCLE clicked");
                 }
                 ));
            }
        }
        private RelayCommand<Person> itemClickCommand;
        public RelayCommand<Person> ItemClickCommand
        {
            get
            {
                return itemClickCommand
                ?? (itemClickCommand = new RelayCommand<Person>(
                  (person) =>
                  {
                      Console.WriteLine($"You clicked {person.LastName}");
                      person.IsSelected = true;
                  }
                 ));
            }
        }
        private ObservableCollection<Person> people = new ObservableCollection<Person>();
        public ObservableCollection<Person> People
        {
            get { return people; }
            set { people = value; }
        }
        public ListCollectionView LCV { get; set; }
        public MainWindowViewModel()
        {
            People.Add(new Person { FirstName = "Chesney", LastName = "Brown" });
            People.Add(new Person { FirstName = "Gary", LastName = "Windass" });
            People.Add(new Person { FirstName = "Liz", LastName = "McDonald" });
            People.Add(new Person { FirstName = "Carla", LastName = "Connor" });
        }
    }
 
