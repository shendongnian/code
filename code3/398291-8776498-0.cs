	private Timer tmr;
	
	protected override void OnStart(string[] args)
	{
		tmr = new Timer (function_to_be_repeated, "...", 5000, 1000);
	}
	protected override void OnStop()
	{
		tmr.Dispose();
	}
