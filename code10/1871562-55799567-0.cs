c#
public class DataPoint
{
    public DataPoint(DateTime timeStamp, double value)
    {
        TimeStamp = timeStamp;
        Value = value;
    }
    public double Value { get; }
    public DateTime TimeStamp { get; }
}
public class GraphData
{
    public string Name { get; set; }
    public List<DataPoint> Data { get; set; }
}
If you want to keep the current flow of extraction (CSV), you can simply LINQ `Zip` the data in to its plottable form.
c#
public partial class MainWindow : Window
{
    public SeriesCollection SeriesCollection { get; set; }
    public Func<double, string> Formatter { get; set; }
    public AxesCollection YAxesCollection { get; set; }
    public List<GraphData> GraphDatas { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        var timeStamps = GetTimeStamps(20);
        GraphDatas = GetGraphData(timeStamps);
        Plot();
    }
    private List<GraphData> GetGraphData(List<DateTime> timeStamps)
    {
        var valuesA = new List<double>() { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8, 9.9, 11.0, 11.0, 9.9, 8.8, 7.7, 6.6, 5.5, 4.4, 3.3, 2.2, 1.1, };
        var valuesB = new List<double>() { 26, 33, 65, 28, 34, 55, 25, 44, 50, 36, 26, 37, 43, 62, 35, 38, 45, 32, 28, 34 };
        var valuesC = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        List<DataPoint> MergeData(List<double> values) => timeStamps.Zip(values, (x, y) => new DataPoint(x, y)).ToList();
        var dataList = new List<GraphData>
        {
            new GraphData() { Name = "DataA", Data = MergeData(valuesA) },
            new GraphData() { Name = "DataB", Data = MergeData(valuesB) },
            new GraphData() { Name = "DataC", Data = MergeData(valuesC) },
        };
        return dataList;
    }
    private void Plot()
    {
        var mapper = Mappers.Xy<DataPoint>()
           .X(dp => (double)dp.TimeStamp.Ticks)
           .Y(dp => dp.Value);
        SeriesCollection = new SeriesCollection(mapper);
        YAxesCollection = new AxesCollection();
        var count = 0;
        foreach (var data in GraphDatas)
        {
            var gLineSeries = new GLineSeries
            {
                Title = data.Name,
                Values = data.Data.AsGearedValues().WithQuality(Quality.Low),
                PointGeometry = null,
                Fill = Brushes.Transparent,
                ScalesYAt = count
            };
            SeriesCollection.Add(gLineSeries);
            YAxesCollection.Add(new Axis() { Title = data.Name });
            count++;
        }
        Formatter = value => new DateTime((long)value).ToString("yyyy-MM:dd HH:mm:ss");
        DataContext = this;
    }
    private List<DateTime> GetTimeStamps(int limit)
    {
        var timeStamps = new List<DateTime>();
        var now = DateTime.Now;
        for (int i = 0; i < limit; i++)
        {
            if (i == 0)
                timeStamps.Add(now);
            else
            {
                now = now.AddDays(1);
                timeStamps.Add(now);
            }
        }
        return timeStamps;
    }
}
XAML
xaml
<lvc:CartesianChart Series="{Binding SeriesCollection}" 
                    AxisY="{Binding YAxesCollection}"
                    DisableAnimations="True"
                    LegendLocation="Right">
    <lvc:CartesianChart.AxisX>
        <lvc:Axis LabelFormatter="{Binding Formatter}" />
    </lvc:CartesianChart.AxisX>
</lvc:CartesianChart>
