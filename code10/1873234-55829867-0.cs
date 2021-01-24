class Program {
        static void Main(string[] args) {
            var loggerFactory = new LoggerFactory().AddNLog();
            var logger = loggerFactory.CreateLogger<Program>();
            var taskFactory = new TaskFactory();
            var clientCount = 1000;
            for (int i = 0; i < clientCount; i++) {
                taskFactory.StartNew(() => {
                    var guid = Guid.NewGuid();
                    var client = new TcpClient();
                    client.Connect(IPAddress.Loopback, 9100);
                    logger.LogInformation($"{guid} Connected");
                    Thread.Sleep(100000);    
                }, TaskCreationOptions.LongRunning);
            }
        }
