    public static class WebBrowserExtensions
    {
    	public static Task LoadPageAsync(this IWebBrowser browser, string address = null)
    	{
    		var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
    
    		EventHandler<LoadingStateChangedEventArgs> handler = null;
    		handler = (sender, args) =>
    		{
    			//Wait for while page to finish loading not just the first frame
    			if (!args.IsLoading)
    			{
    				browser.LoadingStateChanged -= handler;
    				//Important that the continuation runs async using TaskCreationOptions.RunContinuationsAsynchronously
    				tcs.TrySetResult(true);
    			}
    		};
    
    		browser.LoadingStateChanged += handler;
    		
    		if (!string.IsNullOrEmpty(address))
    		{
    			browser.Load(address);
    		}
    
    		return tcs.Task;
    	}
    }
