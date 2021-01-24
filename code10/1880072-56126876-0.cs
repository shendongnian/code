    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons { get; set; }
        public int SelectedId { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Persons = new ObservableCollection<Person>
            {
                new Person { Id = 1, Name = "Raj" },
                new Person { Id = 2, Name = "Ram" }
            };
        }
    }
