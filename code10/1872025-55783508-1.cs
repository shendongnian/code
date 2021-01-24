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
                     People.Add(new Person { FirstName = "Adam", LastName = "Barlow" });
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
            LCV = (ListCollectionView)CollectionViewSource.GetDefaultView(People);
            LCV.SortDescriptions.Add(
                new SortDescription("LastName", ListSortDirection.Ascending));
            People.Add(new Person { FirstName = "Chesney", LastName = "Brown" });
            People.Add(new Person { FirstName = "Gary", LastName = "Windass" });
            People.Add(new Person { FirstName = "Liz", LastName = "McDonald" });
            People.Add(new Person { FirstName = "Carla", LastName = "Connor" });
        }
    }
