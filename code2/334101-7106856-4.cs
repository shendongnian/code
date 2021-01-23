        public static Dictionary<TKey, List<TSrc>> TestGroupBy<TSrc, TKey>
         (this IEnumerable<TSrc> src, Func<TSrc,TKey> groupFunc)
	    {
	     	var dict= new Dictionary<TKey, List<TSrc>>();
			
	      	foreach (TSrc s in src)
	   	    {
		    	TKey key = groupFunc(s);
		    	List<TSrc> list ;
			
		    	if (!dict.TryGetValue(key, out list))
		    	{
		    		list = new List<TSrc>();
		     		dict.Add(key, list);
			    }		
    			list.Add(s);		
    	    	}
		
	    	return dict;
	}
