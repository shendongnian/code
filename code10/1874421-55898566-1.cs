    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Animal> animals { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            animals = new ObservableCollection<Animal>();
            animals.Add(new Animal() { DisplayName = "Pig", Description = "This is a pig" });
            animals.Add(new Animal() { DisplayName = "Dog", Description = "This is a dog" });
            this.DataContext = this;
        }
    }
    public class Animal
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
