    IAsyncDisposable disposable = new AsyncDisposable();
	try
	{
		// Do Something...
	}
	finally
	{
		await disposable.DisposeAsync();
	}
