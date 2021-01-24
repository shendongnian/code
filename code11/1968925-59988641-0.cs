    private async void DoSomething()
    {
        using (var cancellationToken = new CancellationTokenSource())
        {
            await Task.Run(() => 
            {
                for(i = 0; i < 100; i++)
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    //Here's where something is done.
                }
            });
        }
    }
