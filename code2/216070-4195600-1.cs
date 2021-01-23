    private Monitor _monitor { get; set; }
    private Thread _t;
    public void Button_Click(...)
    {
    	_monitor.Cancel()
    	_t.Join()		// will return as your background thread has finished cleanly
    	_t = new Thread(() => _monitor.CurrUsage(nics,950));   
    	t.Start();   
    }
