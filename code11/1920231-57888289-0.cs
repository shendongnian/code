    public class DictionaryComparer<TKey> : IComparer<TKey>
    	{
    		public DictionaryComparer(IDictionary<TKey, int> priorityMap, int defaultPriority)
    		{
    			// TODO: add validations
    			this.PriorityMap = new Dictionary<TKey, int>(priorityMap);
    			this.DefaultPriority = defaultPriority;
    		}
    
    		public int DefaultPriority{get;}
    
    		public IReadOnlyDictionary<TKey, int> PriorityMap{get;}
    
    		public int Compare(TKey x, TKey y)
    		    => this.SafeAccess(x).CompareTo(this.SafeAccess(y));
    
    		private int SafeAccess(TKey key) 
                => this.PriorityMap.TryGetValue(key, out var value)
                   ? value 
                   : this.DefaultPriority;
    	}
