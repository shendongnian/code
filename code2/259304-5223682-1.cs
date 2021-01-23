    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Add a linear Y axis
            int YMax = 150;
            mcChart.Axes.Add(new LinearAxis()
            {
                Minimum = 0,
                Maximum = YMax > 0 ? YMax : 200,
                Orientation = AxisOrientation.Y,
                ShowGridLines = true,
            });
            //Create and set a view model
            var items = Enumerable.Range(0, 50).Select(i => new ChartItemModel { Date = new DateTime(2010, 1, 1).AddDays(i), Value = 30 + i }).ToList();
            this.DataContext = new MainViewModel { LineItems = items };
        }
        //Set Maximum=300
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var yAxis = this.mcChart.ActualAxes.OfType<LinearAxis>().FirstOrDefault(ax => ax.Orientation == AxisOrientation.Y);
            if (yAxis != null)
                yAxis.Maximum = 300;
        }
    }
    public class MainViewModel
    {
        public List<ChartItemModel> LineItems { get; set; }
    }
    public class ChartItemModel
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
