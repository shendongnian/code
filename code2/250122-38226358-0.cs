    public static class Extensions
    {
    	private static readonly ConditionalWeakTable<object, RefId> _ids = new ConditionalWeakTable<object, RefId>();
    
    	public static Guid GetRefId(this object obj)
    	{
    		if (obj == null)
    			return default(Guid);
    			
    		return _ids.GetOrCreateValue(obj).Id;
    	}
    
    	private class RefId
    	{
    		public Guid Id { get; } = Guid.NewGuid();
    	}
    }
