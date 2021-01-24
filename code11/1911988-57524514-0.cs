    private class Server
    {
        public Server(string hostName, string aPort, string fPort, string sSN)
        {
            HostName = hostName;
            APort = aPort;
            FPort = fPort;
            SSN = sSN;
        }
        public string HostName { get; }
        public string APort { get; }
        public string FPort { get; }
        public string SSN { get; }
    }
