    public static class ObservableHelper {
    	public static IConnectableObservable<TSource> WhileResumable<TSource>(Func<bool> condition, IObservable<TSource> source) {
    		var buffer = new Queue<TSource>();
    		var subscriptionsCount = 0;
    		var isRunning = System.Reactive.Disposables.Disposable.Create(() => {
    			lock (buffer)
    			{
    				subscriptionsCount--;
    			}
    		});
    		var raw = Observable.Create<TSource>(subscriber => {
    			lock (buffer)
    			{
    				subscriptionsCount++;
    				if (subscriptionsCount == 1)
    				{
    					while (buffer.Count > 0) {
    						subscriber.OnNext(buffer.Dequeue());
    					}
    					Observable.While(() => subscriptionsCount > 0 && condition(), source)
    						.Subscribe(
    							v => { if (subscriptionsCount == 0) buffer.Enqueue(v); else subscriber.OnNext(v); },
    							e => subscriber.OnError(e),
    							() => { if (subscriptionsCount > 0) subscriber.OnCompleted(); }
    						);
    				}
    			}
    			return isRunning;
    		});
    		return raw.Publish();
    	}
    }
