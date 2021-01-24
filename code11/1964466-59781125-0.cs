    Action f = () => { YOUR REPEATABLE CODE HERE; return FALSE when done repeating. }
    System.Threading.Timer t = new System.Threading.Timer(_ =>
    {
    	if (!f())
    	{
    		t.Dispose();
    		functionToExecuteAfterFinalIteration?.Invoke();
    	}
    }, null, default(TimeSpan), delayBetweenIterations); // delayBetweenIterations is a TimeSpan
