    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            List<Person> persons = new List<Person>();
    
            Person p1 = new Person() { Name = "Person1", Age = 1 };
            p1.FavoriteFoods.Add("Food1");
            p1.FavoriteFoods.Add("Food2");
            p1.FavoriteFoods.Add("Food3");
            p1.FavoriteFoods.Add("Food4");
    
            Person p2 = new Person() { Name = "Person2", Age = 2 };
            p2.FavoriteFoods.Add("Food1");
            p2.FavoriteFoods.Add("Food2");
    
            Person p3 = new Person() { Name = "Person3", Age = 3 };
            p3.FavoriteFoods.Add("Food1");
            p3.FavoriteFoods.Add("Food2");
            p3.FavoriteFoods.Add("Food3");
                
            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);
    
            dg.ItemsSource = persons;
        }
    }
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> FavoriteFoods { get; private set;}
    
        public Person()
        {
            FavoriteFoods = new List<string>();
        }
    }
