        public class EndPoint
        {
            public string HostName { get; set; }
            public int Port { get; set; }
        }
 
        public class EndPointCollection : Collection<EndPoint>
        {
        }
