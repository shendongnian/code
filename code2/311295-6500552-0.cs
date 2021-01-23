    List<int> one = new List<int>{ 3, 4 };
    List<string> two = new List<string>{ "one", "two" };
    
    Parallel.For(0, one.Count + two.Count,
    	index =>
    	{
    		if (index >= one.Count)
    		{
    			int actualIndex = index - one.Count;
    			Console.WriteLine("Dispatch on {0}", two[actualIndex]);
    		}
    		else
    		{
    			Console.WriteLine("Dispatch on {0}", one[index]);
    		}
    	});
