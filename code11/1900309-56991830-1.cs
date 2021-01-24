    public static void Main()
    {
        var collection = Enumerable.Range(0, 1000000).ToArray();
			
    	var st = new Stopwatch();
			
	    var val = 999999;
			
	    st.Start();
			
    	var isExist = collection.Contains(val);
			
    	st.Stop();
			
    	Console.WriteLine("Time taken for Contains : {0}", st.Elapsed.TotalMilliseconds);
			
    	t.Restart();
			
    	var p = BinarySearchArray(collection, 0, collection.Length - 1, val);
			
    	st.Stop();
    	if(p == -1)
	    {
	    	Console.WriteLine("Not Found");
	    }
	    else
	    {
	    	Console.WriteLine("Item found at position : {0}", p);
	    }
			
    	Console.WriteLine("Time taken for binary search {0}", st.Elapsed.TotalMilliseconds);
    }
    private static int BinarySearchArray(int[] inputArray, int lower, int upper, int val)
	{
		if(lower > upper)
			return -1;
			
		var midpoint = (upper + lower) / 2;
			
		if(inputArray[midpoint] == val)
		{
			return midpoint;
		}
		else if(inputArray[midpoint] > val)
		{
			upper  = midpoint - 1;				
		}
		else if(inputArray[midpoint] < val)
		{
			lower =  midpoint+1;	
		}
		
		return BinarySearchArray(inputArray, lower, upper, val);
	}
