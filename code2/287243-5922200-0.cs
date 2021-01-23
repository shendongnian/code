    public abstract class A
    	{
    		private static ConcurrentDictionary<Type, int> _typeIDs = new ConcurrentDictionary<Type, int>();
    		private static int _nextID = 1;
    
    		public int TypeID
    		{
    			get
    			{
    				return _typeIDs.GetOrAdd(this.GetType(), type => System.Threading.Interlocked.Increment(ref _nextID));
    			}
    		}
    	}
