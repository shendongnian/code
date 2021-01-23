    	public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> xss)
    	{
    		var heads = xss.Heads();
    		var tails = xss.Tails();
    
    		var empt = new List<IEnumerable<T>>();
    		if (heads.IsEmpty())
    			return empt;
    		empt.Add(heads);
    		return empt.Concat(tails.Transpose());
    	}
