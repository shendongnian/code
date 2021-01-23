	    List<string> items = new List<string>();
	    Dictionary<string,int> result = new Dictionary<string,int>();
		
	    foreach( int item in items )
	    {
	        if(result.ContainsKey(item) )
	            result[item]++;
	        else
	            result.Add(item,1);
	    }
	    foreach( var item in result )
	        Console.Out.WriteLine( item.Key + ":" + item.Value );
