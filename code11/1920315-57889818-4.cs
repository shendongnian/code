    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel
    {
        public string[] Departures { get; } = new string[] { "Now", "Then", "Later" };
    }
