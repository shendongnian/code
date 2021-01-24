    public partial class MainWindow : Window
    {
        public SeriesCollection senderChart { get; set; }
        public double[] dataValues = { 1, 7, 4, 8, 3, 12, 4, 3, 2, 21, 4, 2, 7, 3, 23, 34, 5, 47, 2, 3, 45, 58, 3, 4 };
        public string[] dateValues = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
                                     , "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public MainWindow()
        {
            var doubleMapperWithMonthColors = new LiveCharts.Configurations.CartesianMapper<double>()
                .X((value, index) => index)
                .Y((value) => value)
                .Fill((v, i) =>
                {
                    switch (i % 12)
                    {
                        case  0: return Brushes.LightBlue; //january
                        case  1: return Brushes.LightCoral; //february
                        case  2: return Brushes.PaleGoldenrod; //march
                        case  3: return Brushes.OrangeRed; //april
                        case  4: return Brushes.BlueViolet; //may
                        case  5: return Brushes.Chocolate; //june
                        case  6: return Brushes.PaleVioletRed; //july
                        case  7: return Brushes.CornflowerBlue; //august
                        case  8: return Brushes.Orchid; //september
                        case  9: return Brushes.Thistle; //october
                        case 10: return Brushes.BlanchedAlmond; //november
                        case 11: return Brushes.YellowGreen; //december 
                        default: return Brushes.Red;
                    }
                });
            LiveCharts.Charting.For<double>(doubleMapperWithMonthColors, SeriesOrientation.Horizontal);
            
            senderChart = new SeriesCollection();
            var columnSeries = new ColumnSeries() { Values = new ChartValues<double>(), DataLabels = true, Title = "Appointments" };
            var labels = this.dateValues;
            foreach (var val in dataValues)
            {
                columnSeries.Values.Add(val);
            }
            this.senderChart.Add(columnSeries);
            DataContext = this;
        }
    }
