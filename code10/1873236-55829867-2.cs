    class Program {
        static void Main(string[] args) {
            var loggerFactory = new LoggerFactory().AddNLog();
            var logger = loggerFactory.CreateLogger<Program>();
            var clientCount = 100;
            for (int i = 0; i < clientCount; i++) {
                var client = new TcpClient();
                client
                    .ConnectAsync(IPAddress.Loopback, 9100)
                    .ContinueWith(async task => {
                        await task;
                        logger.LogInformation("Connected");
                        await Task.Delay(1000000); // a lot of work
                    }, TaskContinuationOptions.LongRunning);
            }
            while (true) { }
        }
    }
