    public sealed class AverageTimeMeter : IDisposable
    {
    	private EnterpriseLibraryPerformanceCounter averageCounter;
    	private EnterpriseLibraryPerformanceCounter baseCounter;
    	private Stopwatch stopWatch;
    	private string instanceName;
    
    	public AverageTimeMeter(EnterpriseLibraryPerformanceCounter averageCounter, EnterpriseLibraryPerformanceCounter baseCounter, string instanceName = null)
    	{
    		this.stopWatch = new Stopwatch();
    		this.averageCounter = averageCounter;
    		this.baseCounter = baseCounter;
    		this.instanceName = instanceName;
    		this.stopWatch.Start();
    	}
    
    	public void Dispose()
    	{
    		this.stopWatch.Stop();
    		if (this.baseCounter != null)
    		{
    			this.baseCounter.Increment();
    		}
    
    		if (this.averageCounter != null)
    		{
    			if (string.IsNullOrEmpty(this.instanceName))
    			{
    				this.averageCounter.IncrementBy(this.stopWatch.ElapsedTicks);
    			}
    			else
    			{
    				this.averageCounter.SetValueFor(this.instanceName, this.averageCounter.Value + this.stopWatch.ElapsedTicks);
    			}
    		}
    	}
    
    }
