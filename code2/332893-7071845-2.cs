    public class TestWrapper
    {
      private Test _test;
      public IObservable<int> Calc()
      {
      	return Observable.Create(obsvr =>
    	{
    		var fixedThreadsched = new EventLoopScheduler();
    		var disp = new BooleanDisposable();
    		while (!disp.IsDisposed)
    		{
    			fixedThreadsched.Schedule(() => obsvr.OnNext(_test.Calc()));
    		}
    		
    		return disp;
    	});
      }
    }
