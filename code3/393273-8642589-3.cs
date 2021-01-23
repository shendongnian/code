    public partial class MainWindow : Window
    {
        public class Person
        {
            public string Name {get;set;}
            public DateTime DOB {get;set;}
        }
        public IList<Person> People { get; set; }
        public MainWindow()
        {
            People = new List<Person>() 
            {
                new Person() {Name = "Martin", DOB = DateTime.Now.AddYears(-20)},
                new Person() {Name = "Lilo", DOB = DateTime.Now.AddYears(-25)}
            };
            InitializeComponent();
            this.DataContext = this;
        }
    }
