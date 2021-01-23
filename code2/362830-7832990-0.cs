    public class ChartSeriesCollection : ObservableCollection<ChartSeries>
    {
    }
    
    ...
    
    public static readonly DependencyProperty ChartSeriesProperty = DependencyProperty.Register(
        "ChartSeries",
        typeof(ChartSeriesCollection),
        typeof(MyClass));
