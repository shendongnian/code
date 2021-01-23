    public static IEnumerable<IList<byte>> Split(IEnumerable<byte> input, IEnumerable<byte> delimiter)
    {
    	var l = new List<byte>();
    	var set = new HashSet<byte>(delimiter);
    	foreach (var item in input)
    	{
    		if(!set.Contains(item))
    			l.Add(item);
    		else if(l.Count > 0)
    		{
    			yield return l;
    			l = new List<byte>();
    		}
    	}
    	if(l.Count > 0)
    		yield return l;
    }
