    public static class RxExt
    {
    	public static IObservable<T> FromMyEvent<T>(this IProperty<T> src)
    	{
    		return System.Reactive.Linq.Observable.Create<T>((obs) =>
    		{
    			Action eh = () => obs.OnNext(src.Value);
    			src.ValueChanged += eh;
    			return () => src.ValueChanged -= eh;
    		});
    	}
    }
