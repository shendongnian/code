    public async Task RunScheduleJob(CancellationToken token)
    {
      while(!token.IsCancellationRequest)
      {
        YourMethod();
        await Task.Delay(TimeSpan.FromHours(1), token)
      }
    }
