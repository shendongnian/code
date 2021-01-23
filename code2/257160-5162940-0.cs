    public class ConnectionFactory : IConnectionFactory
    {
        private int _fromPort;
        public ConnectionFactory(string ip, int fromPort)
        {
            ...
            _fromPort = fromPort;
        }
        public IConnection CreateConnection()
        {
            return new Connection(ip, _fromPort++);
        }
    }
