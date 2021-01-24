            public static async Task Main()
            {
                var symbolList = new ConcurrentBag<string> { "AAPL", "QQQ", "FB", "MSFT", "IBM" };
                var taskArray = new List<Task>();
    
                foreach (var s in symbolList)
                {
                    var task = Task.Run(() =>
                    {
                        Process(s);
                    });
    
                    taskArray.Add(task);
                }
    
                await Task.WhenAll(taskArray);
             }
