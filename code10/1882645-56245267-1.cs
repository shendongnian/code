    public ObservableCollection<Person> Persons { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        Persons = new ObservableCollection<Person>
        {
            new Person() { Name = "Jane", City = "NY", Age = 23 },
            new Person() { Name = "Chelsea", City = "LA", Age = 27 },
            new Person() { Name = "Chris", City = "Chicago", Age = 25 }
        };
        DataContext = this;
    }
