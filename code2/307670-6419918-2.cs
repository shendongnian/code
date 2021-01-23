    public class DataContext : IDataContext
    {
        public Dictionary<string, object> Properties { get; private set; }
        public OperationProgress Progress { get; private set; }
        public DataContext(OperationProgress progress)
        {
            Progress = progress;
        }
    }
