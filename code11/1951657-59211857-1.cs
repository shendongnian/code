    var actions = new Action[] { EventCallBack, LogCallBack, DataCallBack };
    
    await Task.WhenAll(actions.Select(async action =>
	{
		while (_cts.Token.IsCancellationRequested)
		{
			action();
			ExecutionCore(_cts.Token);
			await Task.Delay(ExecutionLoopDelayMs, _cts.Token)
		}
	}, _cts.Token));
