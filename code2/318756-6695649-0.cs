    public MainWindow()
    {
        InitializeComponent();
        ObservableCollection<Person> persons = new ObservableCollection<Person>();
        persons.Add(new Person() { FirstName = "Bob", LastName = "Johnson" });
        persons.Add(new Person() { FirstName = "John", LastName = "Smith" });
        dgA.ItemsSource = new ListCollectionView(persons);
        dgB.ItemsSource = new ListCollectionView(persons);
    }
