    private readonly System.Threading.Timer Timer = null;
    private readonly System.Threading.TimerCallback Callback = null;
    private readonly int Interval = 5000;
	public MyService()
	{
	    Callback = new TimerCallback(this.timerPublish_Elapsed);
        Timer = new System.Threading.Timer(Callback, null, Timeout.Infinite, Timeout.Infinite);
	}
	
	private void Start()
	{
	    Timer.Change(Timespan.Zero, Interval);
	}
	
	private void Stop()
	{
	    Timer.Change(Timeout.Inifinite, Timeout.Inifnite);
	}
	
    protected override void OnStart(string[] args)
    {
        Start();
    }
    protected override void OnStop()
    {
        Stop();
    }
	
	public void Dispose()
	{
	    Dispose(true);
		GC.SuppressFinalize(this);
	}
	
	private void Dispose(bool disposing)
	{
	    if(disposing)
		{
		    if(Timer != null)
			    Timer.Dispose();
		}
	}
