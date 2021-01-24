    public void MyJob( <<other args>>, IJobCancellationToken cancellationToken)
    {
        for (var i = 0; i < Int32.MaxValue; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
    
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
