    public class OneShotTimer
    {
    
    	private volatile readonly Action _callback;
    	private OneShotTimer(Action callback, long msTime)
    	{
    		_callback = callback;
    		dynamic timer = new Threading.Timer(TimerProc);
    		timer.Change(msTime, Threading.Timeout.Infinite);
    	}
    
    	private void TimerProc(object state)
    	{
    		try {
    			// The state object is the Timer object. 
    			((Threading.Timer)state).Dispose();
    			_callback.Invoke();
    		} catch (Exception ex) {
    			// Handle unhandled exceptions
    		}
    	}
    
    	public static OneShotTimer Start(Action callback, TimeSpan time)
    	{
    		return new OneShotTimer(callback, Convert.ToInt64(time.TotalMilliseconds));
    	}
    	public static OneShotTimer Start(Action callback, long msTime)
    	{
    		return new OneShotTimer(callback, msTime);
    	}
    }
