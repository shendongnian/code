            string uri = $"https://localhost:5001";
            int threadCount = 6;
            Thread[] threads = new Thread[threadCount];
            Stopwatch watcher = new Stopwatch();
            for(int i = 0; i < threadCount; ++i)
            {
                threads[i] = new Thread((index) =>
                {
                    var channel = GrpcChannel.ForAddress(uri, new GrpcChannelOptions()
                    {
                        HttpClient = HttpClientFactory.Create(),
                        DisposeHttpClient = true
                    });
                    Console.WriteLine($"Thread({(int)index}) has been started!");
                    for (int req = 0; req < 75; ++req)
                    {
                        var client = new Greeter.GreeterClient(channel);
                        client.SayHello(new HelloRequest()
                        {
                            Name = $"Thread {(int)index}"
                        });
                    }
                    Console.WriteLine($"Thread({(int)index}) has been finished!");
                });
            }
            Thread.Sleep(1000 * 10);
            watcher.Start();
            for (int i = 0; i < threadCount; ++i)
            {
                threads[i].Start(i);
            }
            for (int i = 0; i < threadCount; ++i)
            {
                threads[i].Join();
            }
            watcher.Stop();
            Console.WriteLine($"Elapsed time: {watcher.ElapsedMilliseconds}");
