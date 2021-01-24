    public abstract class DataBaseConnection
    {
        public string ConnectionString { get; }
        public TimeSpan Timeout { get; set; }
        public Stopwatch Stoppy { get; }
        public abstract void OpenConnection();
        public abstract void CloseConnection();
        public DataBaseConnection()
        {
          Timeout = new TimeSpan();
          Stoppy = new StopWatch();
        }
    }
