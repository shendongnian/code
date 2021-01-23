    public static class Ext
    {
    	public static IObservable<T> MergeWithCompleteOnEither<T>(this IObservable<T> source, IObservable<T> right)
    	{
    		return Observable.CreateWithDisposable<T>(obs =>
    		{
    			var compositeDisposable = new CompositeDisposable();
    			var subject = new AsyncSubject<T>();
    			
    			compositeDisposable.Add(source.Subscribe(subject));
    			compositeDisposable.Add(right.Subscribe(subject));
    			compositeDisposable.Add(subject.Subscribe(obs));
    			
    			return compositeDisposable;
    			
    		});		
    	}
    }
