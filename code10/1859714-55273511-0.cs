        static void Main(string[] args)
        {
            using (var watcherManager= new FileSystemWatcherManager())
            {
                watcherManager.OnChangedDetected += (a) =>
                {
                    // General event
                };
                watcherManager.RegisterWatcher(@"C:\temp\helloworld");
                watcherManager.RegisterWatcher(@"C:\temp\api-demo", customChangeEvent: (s, e) =>
                {
                    // Handle change directly
                });
                Console.ReadKey();
            };
       }
