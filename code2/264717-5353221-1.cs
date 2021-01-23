    struct RemoteDetector
    {
        public string Host;
        public int Port;
    }
    
    class Program
    {
        static void Main()
        {
            var oneDetector = new RemoteDetector
            {
                Host = "localhost",
                Port = 999
            };
    
            var remoteDetectors = new[]
            {
                new RemoteDetector 
                { 
                    Host = "localhost", 
                    Port = 999
                }
            };
        }
    }
