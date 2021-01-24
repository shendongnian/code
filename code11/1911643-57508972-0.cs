    public class ViewModel
    {
        public IEnumerable<string> ServerNames { get; }
            = new string[] { "Server 1", "Server 2" };
        public string SelectedServerName { get; set; }
            = "Server 1";
    }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ViewModel();
    }
