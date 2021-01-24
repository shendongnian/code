    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Titles> sortedItems { get; set; }
        public ObservableCollection<Matches> items { get; set; }
        public MainPage()
        {
            InitializeComponent();
            listView.ItemsSource = getData();
        }
        public List<Titles> getData() {
            items = new ObservableCollection<Matches> {
                new Matches {Name="Xander", Description="Writer"},
                new Matches {Name="Rupert", Description="Engineer"},
                new Matches {Name="Tammy", Description="Designer"},
                new Matches {Name="Blue", Description="Speaker"},
            };
            List<Titles> sortedItems = new List<Titles>() {
                new Titles(items.ToList()){ Intro = "This is a big header", Summary = "This is the end" },
                new Titles(items.ToList()){ Intro = "Shift", Summary = "Yeah" },
                new Titles(items.ToList()){ Intro = "This is a big header", Summary = "This is the end" },
            };
            return sortedItems;
        }
    }
