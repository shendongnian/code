    public class ViewModel
    {
        public ViewModel()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 66, 5, 2, 4 },
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4, 6 },
                    ScalesYAt = 1
                },
                new LineSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 4, 2, 7, 2, 7 },
                    ScalesYAt = 2
                }
            };
    
            AxisYCollection = new AxesCollection
            {
                new Axis { Title = "Y Axis 1", Foreground = Brushes.Gray },
                new Axis { Title = "Y Axis 2", Foreground = Brushes.Red },
                new Axis { Title = "Y Axis 3", Foreground = Brushes.Brown }
            };
        }
            
        public AxesCollection AxisYCollection { get; set; }
            
        public SeriesCollection SeriesCollection { get; set; }
    
    }
