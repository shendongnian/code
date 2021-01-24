    public static class Extensions
    {
    
    	private static Random rng = new Random();  
        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize) 
        {
            return source.Shuffle()
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)  
    	{  
    		var collection = list.ToList();
    	    int n = collection.Count();
    	    while (n > 1) 
    		{  
    	        n--;  
    	        int k = rng.Next(n + 1);  
    	        T value = collection[k];  
    	        collection[k] = collection[n];  
    	        collection[n] = value;  
    	    } 
    		return collection;
    	}
    }
