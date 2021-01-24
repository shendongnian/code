    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Create date labels
            Labels = new string[10];
            for (int i = 0; i < Labels.Length; i++)
            {
                Labels[i] = DateTime.Now.Add(TimeSpan.FromDays(i)).ToString("dd MMM yyyy");
            }
            var chartValues = new ChartValues<double>
            {
                4,
                5,
                7,
                double.NaN,
                double.NaN,
                5,
                2,
                8,
                double.NaN,
                6
            };
            Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Dataset 1",
                    Values = ProcessChartValues(chartValues)
                },
                new LineSeries
                {
                    Title = "Dataset 2",
                    Values = new ChartValues<double>
                    {
                        2,
                        3,
                        4,
                        5,
                        6,
                        3,
                        1,
                        4,
                        5,
                        3
                    }
                }
            };
            DataContext = this;
        }
        private ChartValues<double> ProcessChartValues(ChartValues<double> chartValues)
        {
            var tmpChartValues = new ChartValues<double>();
            double bornLeft =0, bornRight=0;
            double xz = 0, zy = 0, xy = 0;
            bool gapFound = false;
            foreach (var point in chartValues)
            {
                if (!double.IsNaN(point))
                {
                    if (gapFound)
                    {
                        // a gap was found and it needs filling 
                        bornRight = point;
                        xz = Math.Abs(bornLeft - bornRight);
                        for (double i = zy; i >0; i--)
                        {
                            tmpChartValues.Add((xz / zy) * i + Math.Min(bornLeft, bornRight));
                        }
                        tmpChartValues.Add(point);
                        gapFound = false;
                        zy = 0;
                    }
                    else
                    {
                        tmpChartValues.Add(point);
                        bornLeft = point;
                    }
                }
                else if(gapFound)
                {
                    zy += 1;
                }
                else
                {
                    zy += 1;
                    gapFound = true;
                }
            }
            return tmpChartValues;
        }
        public SeriesCollection Series { get; set; }
        public string[] Labels { get; set; }
    }
