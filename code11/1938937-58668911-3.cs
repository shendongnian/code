    public static class Extensions
    {
    	public static Dictionary<TValue, TKey> Reverse<TKey, TValue>(this IDictionary<TKey, TValue> source)
    	{
    	     var dictionary = new Dictionary<TValue, TKey>();
    	     foreach (var entry in source)
    	     {
    	         if(!dictionary.ContainsKey(entry.Value))
    	             dictionary.Add(entry.Value, entry.Key);
    	     }
    	     return dictionary;
    	} 
    	
    	 public static Dictionary<TKey,TValue> Merge<TKey,TValue>(this IEnumerable<IDictionary<TKey,TValue>> source)
           
        {
            return source.SelectMany(dict => dict)
                             .ToLookup(pair => pair.Key, pair => pair.Value)
                             .ToDictionary(group => group.Key, group => group.First());
        }
    
    }
