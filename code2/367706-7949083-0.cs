    public static class ObservableEx
    {
    	public static Func<T, IObservable<R>> FromAsyncCallbackPattern<T, R>(
    		this Action<T, Action<R>> call)
    	{
    		if (call == null) throw new ArgumentNullException("call");
    		return t =>
    		{
    			var subject = new AsyncSubject<R>();
    			try
    			{
    				Action<R> callback = r =>
    				{
    					subject.OnNext(r);
    					subject.OnCompleted();
    				};
    				call(t, callback);
    			}
    			catch (Exception ex)
    			{
    				return Observable.Throw<R>(ex, Scheduler.ThreadPool);
    			}
    			return subject.AsObservable<R>();
    		};
    	}
    }
