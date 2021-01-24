    public class Optional<T>
    {
    	private readonly bool _hasValue;
    	private readonly T _value;
    	public Optional(T t)
    	{
    		_value = t;
    		_hasValue = true;
    	}
    	
    	public Optional()
    	{
    		_hasValue = false;
    		_value = default(T);
    	}
    	
    	public bool HasValue => _hasValue;
    	public T Value 
    	{
    		get 
    		{
    			if(HasValue)
    				return _value;
    			else
    				throw new InvalidOperationException("No value present");
    		}
    	}
    }
    public static class X { 
    	public static IObservable<Optional<T>> ToOptional<T>(this IObservable<T> source)
    	{
    		return source.Publish(_source => _source
    			.Select(t => new Optional<T>(t))
    			.LastOrDefaultAsync()
    			.Select(n => n.Equals(default(Optional<T>)) ? new Optional<T>() : n)
    		);
    	}
    }
    
