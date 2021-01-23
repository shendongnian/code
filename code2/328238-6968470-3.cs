    void Main()
    {
	    var rand = new Random();
    
	    var xss = new [] {
		    new [] {rand.NextDouble(), rand.NextDouble()},
    		new [] {rand.NextDouble(), rand.NextDouble()},
		    new [] {rand.NextDouble(), rand.NextDouble()},
	    };
    	xss.Dump("Original");
	    xss.Transpose().Dump("Transpose");
    }
    
    public static class Extensions
    {
	    public static IEnumerable<T> Heads<T>(this IEnumerable<IEnumerable<T>> xss)
    	{
		    Debug.Assert(xss != null);
    		if (xss.Any(xs => xs.Count() == 0))
			    return new List<T>();
		    return xss.Select(xs => xs.First());
	    }
    	
	    public static bool IsEmpty<T>(this IEnumerable<T> xs)
    	{
		    return xs.Count() == 0;
	    }
    	
	    public static IEnumerable<IEnumerable<T>> Tails<T>(this IEnumerable<IEnumerable<T>> xss)
    	{
		    return xss.Select(xs => xs.Skip(1));
	    }
    	
	    public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> xss)
    	{
    //		xss.Dump("xss in Transpose");
		    var heads = xss.Heads()
    //			.Dump("heads in Transpose")
			    ;
		    var tails = xss.Tails()
    //			.Dump("tails in Transpose")
			    ;
    
		    var empt = new List<IEnumerable<T>>();
    		if (heads.IsEmpty())
			    return empt;
		    empt.Add(heads);
    		return empt.Concat(tails.Transpose())
    //			.Dump("empt")
			    ;
	    }
    }
