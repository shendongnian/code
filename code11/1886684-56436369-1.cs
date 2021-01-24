    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            oxyplot.Model.Axes[0].Minimum = 20;
            oxyplot.InvalidatePlot();
            oxyplot.Model.InvalidatePlot(true);
        }
    }
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.MyModel = new PlotModel { Title = "Example 1" };
            this.MyModel.Axes.Add(new LinearAxis() { Minimum = 10, Maximum = 100, Position = AxisPosition.Bottom });
        }
        public PlotModel MyModel { get; private set; }
    }
