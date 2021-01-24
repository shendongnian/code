    public async Task MyLockedMethod()
    {
    	lock(_myLock)
    	{
    		await MyAsyncMethod();
    	}
    }
