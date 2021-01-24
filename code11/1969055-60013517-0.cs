    public async void _browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
    {
    	if (!e.IsLoading)
    	{
    		if (previousRequestNrWhereLoadingFinished < _requestHandler.NrOfCalls)
    		{
    			previousRequestNrWhereLoadingFinished = _requestHandler.NrOfCalls;
    			source = await e.Browser.MainFrame.GetSourceAsync();
    			...
    		}
    	}
    }
