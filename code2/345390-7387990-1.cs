    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Person> people = new List<Person>();
            people.Add(new Person() 
            { 
                Name = "John Doe",
                Age = 32,
                Active = true
            });
            people.Add(new Person()
            {
                Name = "Jane Doe",
                Age = 30,
                Active = true
            });
            people.Add(new Person()
            {
                Name = "John Adams",
                Age = 64,
                Active = false
            });
            tblLog.ItemsSource = people;
        }
    }
