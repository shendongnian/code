    public class CustomEnumerable<T> : IEnumerable<T>
    {
    	public CustomEnumerable(IEnumerable<T> source)
    	{
    		_internalEnumerator = new CustomEnumerator<T>(source.GetEnumerator());
    	}
    
    	private IEnumerator<T> _internalEnumerator;
    	public IEnumerator<T> GetEnumerator()
    	{
    		return _internalEnumerator;
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return _internalEnumerator;
    	}
    }
