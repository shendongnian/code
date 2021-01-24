    public partial class MainWindow : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { 3 }
                }
            };
            DataContext = this;
        }
    }
