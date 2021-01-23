    public static IObservable<U> SelectAsync<T, U>(this IObservable<T> source,
    	Func<T, U> selector)
    {
    	var subject = new Subject<U>();
    	var queue = new Queue<System.Threading.Tasks.Task<U>>();
    	var completing = false;
    	var subscription = (IDisposable)null;
    	
    	Action<Exception> onError = ex =>
    	{
    		queue.Clear();
    		subject.OnError(ex);
    		subscription.Dispose();
    	};
    	
    	Action dequeue = () =>
    	{
    		lock (queue)
    		{
    			var error = false;
    			while (queue.Count > 0 && queue.Peek().IsCompleted)
    			{
    				var task = queue.Dequeue();
    				if (task.Exception != null)
    				{
    					error = true;
    					onError(task.Exception);
    					break;
    				}
    				else
    				{
    					subject.OnNext(task.Result);
    				}
    			}
    			if (!error && completing && queue.Count == 0)
    			{
    				subject.OnCompleted();
    				subscription.Dispose();
    			}
    		}
    	};
    	
    	Action<T> enqueue = t =>
    	{
    		if (!completing)
    		{
    			var task = new System.Threading.Tasks.Task<U>(() => selector(t));
    			queue.Enqueue(task);
    			task.ContinueWith(tu => dequeue());
    			task.Start();
    		}
    	};
    
    	subscription = source.Subscribe(
    		t => { lock(queue) enqueue(t); },
    		x => { lock(queue) onError(x); },
    		() => { lock(queue) completing = true; });
    		
    	return subject.AsObservable();
    }
