    private bool _processing;
    public void timer_Elapsed(object sender, EventArgs e)
    {
        if(!_processing)
    	{
    		_processing = true;
    		// do processing
    		_processing = false;
    	}
    }
