    private volatile bool isntSignaledStop = true;
    private async void ButtonStart_Click(object sender, EventArgs e)
    {
    	await MenuLoop();
    	Close();
    }
    
    private Task MenuLoop()
    {
    	return Task.Run(() =>
    	{
    		while (isntSignaledStop)
    		{
    			HeavyMethod();
    			Invoke(DelegateWriteResultsToMenu);
    
    			HeavyMethod();
    			Invoke(DelegateWriteResultsToMenu);
    		}
    	});
    }
    private void ButtonStop_Click(object sender, EventArgs e)
    {
    	isntSignaledStop = false;
    }
