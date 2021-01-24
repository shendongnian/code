    public interface IMixableDataset<out TData>
    {
        IReadOnlyCollection<TData> Data { get; }
    }
    public class LineChartDataset<TData> : IMixableDataset<TData>
    {
        private readonly List<TData> _list = new List<TData>();
        public IReadOnlyCollection<TData> Data => _list;
        public void AddRange(IEnumerable<TData> collection) => _list.AddRange(collection);
    }
    public class LineChartData
    {
        public HashSet<IMixableDataset<object>> Datasets { get; } = new HashSet<IMixableDataset<object>>();
    }
    public class LineChartConfig
    {
        public LineChartData ChartData { get; } = new LineChartData();
    }
    public class Demo
    {
        public void DesiredUseCase()
        {
            LineChartConfig config = new LineChartConfig();
            // Must use reference types to take advantage of type variance in C#
            LineChartDataset<string> intDataset = new LineChartDataset<string>();
            // Using the non-interface method to add the range, you can still mutate the object
            intDataset.AddRange(new[] { "1", "2", "3", "4", "5" });
            // Your original code works fine when reference types are used
            config.ChartData.Datasets.Add(intDataset);
        }
    }
