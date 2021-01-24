    public partial class MainWindow : Window
    {
        public List<DisplayData> DisplayList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DisplayList = new List<DisplayData>
            {
                new DisplayData() { DisplayText = "A" },
                new DisplayData() { DisplayText = "B" },
                new DisplayData() { DisplayText = "C" }
            };
            DataContext = this;
        }
    }
