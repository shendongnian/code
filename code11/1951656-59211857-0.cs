    var actions = new Action[] { EventCallBack, LogCallBack, DataCallBack };
    
    await Task.WhenAll(actions.Select(action => Task.Run(() =>
    {
    	while (!_cts.Token.WaitHandle.WaitOne(ExecutionLoopDelayMs))
    	{
    		action();
    		ExecutionCore(_cts.Token);
    	}
    }, _cts.Token)));
