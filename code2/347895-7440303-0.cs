    private Dictionary<string, Task<string>> _requests
    	= new Dictionary<string, Task<string>>();
    
    public string Search(string key)
    {
    	Task<string> task;
    	lock (_requests)
    	{
    		if (_requests.ContainsKey(key))
    		{
    			task = _requests[key];
    		}
    		else
    		{
    			task = Task<string>
    				.Factory
    				.StartNew(() => DoSearch(key));
    			_requests[key] = task;
    			task.ContinueWith(t =>
    			{
    				lock(_requests)
    				{
    					_requests.Remove(key);
    				}
    			});
    		}
    	}
    	return task.Result;
    }
