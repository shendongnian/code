    [Serializable]
    public class ConnectionFailedException : Exception
    {
        public ConnectionFailedException(string message, string connectionString)
            : base(message)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; private set; }
    }
