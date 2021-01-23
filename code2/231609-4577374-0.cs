    private CancellationTokenSource cts;
    public void StartEngine()
    {
        if (cts == null)
        {
            cts = new CancellationTokenSource();
            Task.Factory.StartNew(() => GameLoop(cts.Token), cts.Token);
        }
    }
    private void GameLoop(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(1000);
            Debug.WriteLine("working...");
        }
    }
    public void StopEngine()
    {
        if (cts != null)
        {
            cts.Cancel();
            cts = null;
        }
    }
