    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ItemsToDisplay = new System.Collections.ObjectModel.ObservableCollection<Item>();
            ItemsToDisplay.Add(new Item("Homer", 45));
            ItemsToDisplay.Add(new Item("Marge", 42));
            ItemsToDisplay.Add(new Item("Bart", 10));
            ItemsToDisplay.Add(new Item("Lisa", 8));
            ItemsToDisplay.Add(new Item("Maggie", 2));
        }
        public System.Collections.ObjectModel.ObservableCollection<Item> ItemsToDisplay { get; private set; }
    }
    public class Item
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Item(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
