    public sealed partial class MainPage : Page
    {
        public List<Project> Projects = new List<Project>();
        public MainPage()
        {
            this.InitializeComponent();     
    
            Projects.Add(new Project() { ProjName = "Projekt1" });       
            list.ItemsSource = Projects;
        }
        public string TestString { get; set; }
    }
