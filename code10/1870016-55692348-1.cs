	public static Task MyWhenAll(Task t1, Task t2)
	{
		var tcs = new TaskCompletionSource<object>();
		var _ = Impl();
		return tcs.Task;
		async Task Impl()
		{
			await Task.Delay(10);
			try
			{
				await Task.WhenAll(t1, t2);
				tcs.SetResult(null);
			}
			catch
			{
				tcs.SetException(new[] { t1.Exception, t2.Exception });
			}
		}
	}
