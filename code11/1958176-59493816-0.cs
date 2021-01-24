    public partial class Form1 : Form
    {
        private Series series = new Series("series")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.Red
        };
        private Series correction = new Series("correction")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.Transparent,
            IsVisibleInLegend = false,
            IsValueShownAsLabel = false,
        };
        public Form1()
        {
            InitializeComponent();
            series.Points.AddXY(0, 0);
            series.Points.AddXY(0, 3);
            chart1.Series.Add(series);
            correction.Points.AddXY(1, 1);
            chart1.Series.Add(correction);
        }
    }
