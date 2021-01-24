    public class DisposableHostedService : IHostedService, IDisposable
    {
    	private Timer _timer;
    	private bool _disposed;
    
    	public Task StartAsync(CancellationToken cancellationToken)
    	{
    		_timer = new Timer(RunSmokeTests, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
    		return Task.CompletedTask;
    	}
    
    	public Task StopAsync(CancellationToken cancellationToken)
    	{
    		_timer?.Change(Timeout.Infinite, 0);
    		return Task.CompletedTask;
    	}
    
    	public void Dispose()
    	{
    		Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    
    	protected virtual void Dispose(bool disposing)
    	{
    		if (_disposed)
    			return;
    
    		if (disposing)
    		{
    			_timer?.Dispose();
    		}
    
    		_disposed = true;
    	}
    
    	private void DoWork(object state)
    	{
    	}
    }
