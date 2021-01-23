            InitializeComponent();
            ObservableCollection<Person> persons = new ObservableCollection<Person>() { 
                new Person(){ FirstName = "John", LastName = "Doe", Age = 25 },
                new Person(){ FirstName = "John", LastName = "Smith", Age = 35 },
                new Person(){ FirstName = "Susan", LastName = "Smith", Age = 31 },
                new Person(){ FirstName = "Anthony", LastName = "Jones", Age = 31 },
            };
            ComboBox1.ItemsSource = persons;
