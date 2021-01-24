	public async Task<uint> AwaitEach()
	{
		var list = new List<Task>();
		
		for (var i = 0; i < 10; i++)
		{
			list.Add(Task.Delay(1));
		}
		
		for (var i = 0; i < 10; i++)
		{
			await list[i].ConfigureAwait(false);
		}
		return 123;
	}
