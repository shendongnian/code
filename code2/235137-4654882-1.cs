    public static class Cache
    {
    	private static readonly object _syncRoot = new object();
    	private static Dictionary<Type, string> _lookup = new Dictionary<Type, string>();
    
    	public static class OneToManyLocker
    	{
    		private static readonly Object WriteLocker = new Object();
    		private static readonly List<Object> ReadLockers = new List<Object>();
    		private static readonly Object myLocker = new Object();
    		
    		public static Object GetLock(LockType lockType)
    		{
    			lock(WriteLocker)
    			{
    				if(lockType == LockType.Read)
    				{
    					var newReadLocker = new Object();
    					lock(myLocker)
    					{
    						ReadLockers.Add(newReadLocker);
    					}
    					return newReadLocker;
    				}
    			
    				foreach(var readLocker in ReadLockers)
    				{
    					lock(readLocker) { }
    				}
    											
    				return WriteLocker;
    			}
    		}
    		
    		public enum LockType {Read, Write};
    	}
    
    	public static void Add(Type type, string value)
    	{
    		lock(OneToManyLocker.GetLock(OneToManyLocker.LockType.Write))
    		{
    			_lookup.Add(type, value);
    		}
    	}
    
    	public static string Lookup(Type type)
    	{
    		string result;
    		lock (OneToManyLocker.GetLock(OneToManyLocker.LockType.Read))
    		{
    			_lookup.TryGetValue(type, out result);		
    		}
    	
    		return result;
    	}
    }
