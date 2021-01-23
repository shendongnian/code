    var taskTest = Task.Factory.StartNew(() =>
    {
        System.Threading.Thread.Sleep(5000);
    
    });
    taskTest.ContinueWith((Task t) =>
    {
        Console.WriteLine("ERR");
    }, TaskContinuationOptions.OnlyOnFaulted);
