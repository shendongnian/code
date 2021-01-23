    private readonly System.Threading.Timer Timer = null;
    private readonly System.Threading.TimerCallback Callback = null;
	
	public MyService()
	{
	    Callback = new TimerCallback(this.timerPublish_Elapsed);
        Timer = new System.Threading.Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.Zero);
	}
	
	private void Start()
	{
	    Timer.Change(5000, 5000);
	}
	
	private void Stop()
	{
	    Timer.Change(TimeSpan.Zero, TimeSpan.Zero);
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
