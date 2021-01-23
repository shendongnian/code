    var task1 = Task.Factory.StartNew(() =>
    {
        throw new MyCustomException("Task1 faulted.");
    })
    .ContinueWith((t) =>
        {
            Console.WriteLine("I have observed a {0}",
                t.Exception.InnerException.GetType().Name);
        },
        TaskContinuationOptions.OnlyOnFaulted);
