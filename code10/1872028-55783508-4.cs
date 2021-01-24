    public class MainWindowViewModel : BaseViewModel
    {
        private RelayCommand addPersonCommand;
        public RelayCommand AddPersonCommand
        {
            get
            {
                return addPersonCommand
                ?? (addPersonCommand = new RelayCommand(
                  () =>
                  {
                      Person person = new Person { FirstName = "Adam", LastName = "Barlow" };
                      People.Add(person);
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
            LCV = new ListCollectionView(People);
            LCV.SortDescriptions.Add(
                new SortDescription("LastName", ListSortDirection.Ascending));
        }
    }
