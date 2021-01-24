    public abstract class DataBaseConnection
    {
        protected bool CurrentConnection;
        public string ConnectionString { get; }
        public TimeSpan Timeout { get; }
        public Stopwatch Stoppy { get; }
        public abstract void OpenConnection();
        public abstract void CloseConnection();
        public DataBaseConnection()
        {
          Timeout = new TimeSpan();
          Stoppy = new StopWatch();
        }
    }
