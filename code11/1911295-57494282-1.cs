    public abstract class FuncHolder<T, TResult>
    {
    	[JsonIgnore]
    	public abstract Func<T, TResult> Value { get; }
    }
    
    public static class FuncHolder
    {
    	private static Dictionary<int, object> _metadataTokenToMethodDictionary = new Dictionary<int, object>();
    	
    	private class FuncHolderImplementation<T, TResult> : FuncHolder<T, TResult>
    	{
    		public int MetadataToken { get; }
    
    		public FuncHolderImplementation(int metadataToken)
    		{
    			MetadataToken = metadataToken;
    		}
    
    		public override Func<T, TResult> Value => (Func<T, TResult>)_metadataTokenToMethodDictionary[MetadataToken];
    	}
    
    	public static FuncHolder<T, TResult> GetFuncHolder<T, TResult>(Func<T, TResult> func)
    	{
    		if (!_metadataTokenToMethodDictionary.ContainsKey(func.Method.MetadataToken))
    		{
    			_metadataTokenToMethodDictionary[func.Method.MetadataToken] = func;
    		}
    
    		return new FuncHolderImplementation<T, TResult>(func.Method.MetadataToken);
    	}
    }
