    namespace MMExtensions
    {
    	public static class DictionaryExtensions
    	{
    		public delegate bool Predicate<TKey, TValue>(KeyValuePair<TKey, TValue> d);
    
    		[MethodImpl(MethodImplOptions.Synchronized)]
    		public static void Filter<TKey, TValue>(
    			this Dictionary<TKey, TValue> hashtable, Predicate<TKey, TValue> p)
    		{
    			foreach (KeyValuePair<TKey, TValue> value in hashtable.ToList().Where(value => !p(value)))
    				hashtable.Remove(value.Key);
    		}
    	}
    }
