            string processorHostName = Guid.NewGuid().ToString();
            var Options = new EventProcessorOptions()
            {
                MaxBatchSize = 1, //not required to make it working, just for testing
            };
            Options.SetExceptionHandler((ex) =>
            {
                System.Diagnostics.Debug.WriteLine($"Exception : {ex}");
            });
            var eventHubCS = "event hub connection string";
            var storageCS = "storage connection string";
            var containerName = "test";
            var eventHubname = "test2";
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventHubname, "$Default", eventHubCS, storageCS, containerName);
            eventProcessorHost.RegisterEventProcessorAsync<MyEventProcessor>(Options).Wait();
 
