	public static void DownloadString(
		this Uri uri,
		Action<string> action,
		Action<Exception> exception)
	{
		if (uri == null) throw new ArgumentNullException("uri");
		if (action == null) throw new ArgumentNullException("action");
		
		var webclient = (WebClient)null;
		
		Action<Action> catcher = body =>
		{
			try
			{	
				body();
			}
			catch (Exception ex)
			{
				ex.Data["uri"] = uri;
				if (exception != null)
				{
					exception(ex);
				}
			}
			finally
			{
				if (webclient != null)
				{
					webclient.Dispose();
				}
			}
		};
		
		var handler = (DownloadStringCompletedEventHandler)null;		
		handler = (s, e) =>
		{
			var result = (string)null;
			catcher(() =>
			{	
				result = e.Result;
				webclient.DownloadStringCompleted -= handler;
			});
			action(result);
		};
			
		catcher(() =>
		{	
			webclient = new WebClient();
			webclient.DownloadStringCompleted += handler;
			webclient.DownloadStringAsync(uri);
		});
	}
