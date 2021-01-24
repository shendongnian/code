    static void Main(string[] args)
    {
    	var values = new[] { 5, 7, 8, 9, 10, 10, 8, 2, 1 };
    
    	var i = 0;
    
    	foreach (var (x, y) in Pairwise(values))
    	{
    		if (x < y)
    		{
    			i++;
    			if (i == 4)
    				Console.WriteLine("Hello world!");
    		}
    	}
    
    	Console.ReadLine();
    }
