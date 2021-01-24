    [AsyncStateMachine(typeof(<GetValue>d__1))]
    public Task<int> GetValue()
    {
    	<GetValue>d__1 stateMachine = default(<GetValue>d__1);
    	stateMachine.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
    	stateMachine.<>1__state = -1;
    	AsyncTaskMethodBuilder<int> <>t__builder = stateMachine.<>t__builder;
    	<>t__builder.Start(ref stateMachine);
    	return stateMachine.<>t__builder.Task;
    }
    [StructLayout(LayoutKind.Auto)]
    [CompilerGenerated]
    private struct <GetValue>d__1 : IAsyncStateMachine
    {
    	public int <>1__state;
    
    	public AsyncTaskMethodBuilder<int> <>t__builder;
    
    	private TaskAwaiter <>u__1;
    
    	private void MoveNext()
    	{
    		int num = <>1__state;
    		int result;
    		try
    		{
    			TaskAwaiter awaiter;
    			if (num != 0)
    			{
    				awaiter = Task.Delay(TimeSpan.FromSeconds(1.0)).GetAwaiter();
    				if (!awaiter.IsCompleted)
    				{
    					num = (<>1__state = 0);
    					<>u__1 = awaiter;
    					<>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
    					return;
    				}
    			}
    			else
    			{
    				awaiter = <>u__1;
    				<>u__1 = default(TaskAwaiter);
    				num = (<>1__state = -1);
    			}
    			awaiter.GetResult();
    			result = 42;
    		}
    		catch (Exception exception)
    		{
    			<>1__state = -2;
    			<>t__builder.SetException(exception);
    			return;
    		}
    		<>1__state = -2;
    		<>t__builder.SetResult(result);
    	}
    
    	void IAsyncStateMachine.MoveNext()
    	{
    		//ILSpy generated this explicit interface implementation from .override directive in MoveNext
    		this.MoveNext();
    	}
    
    	[DebuggerHidden]
    	private void SetStateMachine(IAsyncStateMachine stateMachine)
    	{
    		<>t__builder.SetStateMachine(stateMachine);
    	}
    
    	void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
    	{
    		//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
    		this.SetStateMachine(stateMachine);
    	}
    }
