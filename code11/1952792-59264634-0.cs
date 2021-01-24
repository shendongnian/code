    try
	{
		Task t = Socket.ConnectAsync(endpoint.Endpoint);
		t.Wait();
	}
	catch (AggregateException ae)
	{
		if (ae.InnerException != null)
			throw ae.InnerException;
	}
