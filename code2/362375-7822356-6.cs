    public static IObservable<TResult> Generate<TState, TResult>(
    	TState initialState,
    	Func<TState, bool> condition,
    	Func<TState, TState> iterate,
    	Func<TState, TResult> resultSelector,
    	IScheduler scheduler)
    {
        return new AnonymousObservable<TResult>((IObserver<TResult> observer) =>
    	{
            TState state = initialState;
            bool first = true;
            return scheduler.Schedule((Action self) =>
    		{
                bool flag = false;
                TResult local = default(TResult);
                try
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        state = iterate(state);
                    }
                    flag = condition(state);
                    if (flag)
                    {
                        local = resultSelector(state);
                    }
                }
                catch (Exception exception)
                {
                    observer.OnError(exception);
                    return;
                }
                if (flag)
                {
                    observer.OnNext(local);
                    self();
                }
                else
                {
                    observer.OnCompleted();
                }
            });
        });
    }
