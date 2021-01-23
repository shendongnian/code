    private void LoadWaitCursor()
    {
    	this.Dispatcher.Invoke((Action)(() =>
    	{
    		Mouse.OverrideCursor = Cursors.Wait;
    	}));
    }
    private void LoadDefaultCursor()
    {
    	this.Dispatcher.Invoke((Action)(() =>
    	{
    		Mouse.OverrideCursor = null;
    	}));
    }
