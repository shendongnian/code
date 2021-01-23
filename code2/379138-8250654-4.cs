    BackgroundWorker worker = new BackgroundWorker();
    int value;
    worker.DoWork += (s, e) =>
    {
        this.Invoke((MethodInvoker) delegate { value = DoSomething(); });
    };
    
    worker.RunWorkerAsync();
    
    // do other processing
    while (worker.IsBusy)
    {
        // Some other task
    }
    
    // Use the value
    foo(value);
