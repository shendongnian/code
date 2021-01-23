    public class TestWrapper
    {
    	public TestWrapper(Func<Test> factory)
    	{
    		_scheduler = new EventLoopScheduler();
    		_test = Observable.Start(factory, _scheduler).First();
    	}
    
    	private readonly EventLoopScheduler _scheduler;
    	private readonly Test _test;
    	
      	public IObservable<int> Calc()
    	{
    		return Observable.Start(() => _test.Calc(), _scheduler);
    	}
    }
