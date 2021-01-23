    private async void Listen()
    {
        while (!cts.IsCancellationRequested)
        {
            HttpListenerContext context = await listener.GetContextAsyncTask();
            Console.WriteLine("Client connected " + ++counter);
            ProcessRequest(context, counter);
        }
        listener.Close();
    }
    private async void ProcessRequest(HttpListenerContext context, int c)
    {
        await TaskEx.Delay(5000, cts.Token);
        Console.WriteLine("Response " + c);
    }
