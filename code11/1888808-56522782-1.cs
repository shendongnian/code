    public sealed partial class MainPage : Page
    {
        private Timer DataTimer;        // timer to periodically add data to the chart
        private int LineCount = 1;      // arbitrary line counter to differentiate lines from each other
        private DataTemplate ChartTrackIntersectionTemplate;
        // custom class for holding the data to be displayed on the chart
        private class Data
        {
            public int XValue { get; set; }
            public int YValue { get; set; }
        }
        // overarching class that holds all of the data for ONE line/series
        private class DataToChart
        {
            // List of all the data points within this instance of DataToChart
            public List<Data> DataPoints;
            // Constructor to initialise DataPoints
            public DataToChart()
            {
                DataPoints = new List<Data>();
            }
        }
        // Overarching container to hold data for ALL lines/series
        private ObservableCollection<DataToChart> allData = new ObservableCollection<DataToChart>();
        public MainPage()
        {
            this.InitializeComponent();
            // set up the timer to call every 10s to add new data to the chart. warning: this will run infinitely
            DataTimer = new Timer(DataCallback, null, (int)TimeSpan.FromSeconds(10).TotalMilliseconds, Timeout.Infinite);
            ChartTrackIntersectionTemplate = this.Resources["ChartTrackIntersectionTemplate"] as DataTemplate;
            allData.CollectionChanged += AllData_CollectionChanged;
        }
        private void AllData_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (DataToChart data in e.NewItems)
            {
                // Make a series for the line
                ScatterLineSeries scatterLineSeries = new ScatterLineSeries
                {
                    Name = $"Line {LineCount}",
                    ItemsSource = data.DataPoints,
                    XValueBinding = new PropertyNameDataPointBinding("XValue"),
                    YValueBinding = new PropertyNameDataPointBinding("YValue"),
                    DisplayName = $"Line {LineCount}",
                    LegendTitle = $"Line {LineCount}",
                };
                ChartTrackBallBehavior.SetIntersectionTemplate(scatterLineSeries, ChartTrackIntersectionTemplate);
                // Add the line to the Chart's Series collection
                MainChart.Series.Add(scatterLineSeries);
                // Increment arbitrary counter
                LineCount++;
            }
        }
        // Generic callback to call AddLineToChart() on the other thread to handle the Chart's data
        private async void DataCallback(object state)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => AddLineToChart());
        }
        // Code to handle adding a line to the chart
        private void AddLineToChart()
        {
            // Using Random() to create random data
            Random rand = new Random();
            DataToChart dataToChart = new DataToChart();
            for (int i = 0; i < 50; i++)
            {
                dataToChart.DataPoints.Add(new Data
                {
                    XValue = i,
                    YValue = rand.Next(0, 100)
                });
            }
            // Add the data for this line/series to the overarching container
            allData.Add(dataToChart);
            DataTimer.Change((int)TimeSpan.FromSeconds(10).TotalMilliseconds, Timeout.Infinite);
        }
    }
