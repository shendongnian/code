    var tokenSource = new CancellationTokenSource();
    var token = tokenSource.Token;
 
    Task.Factory.StartNew( () => DoSomeWork(1, token), token);
    static void DoSomeWork(int taskNum, CancellationToken ct)
    {
        // Do work here, checking and acting on ct.IsCancellationRequested where applicable, 
    }
