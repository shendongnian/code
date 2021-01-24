    static void Main(string[] args)
    {
    
    	int[] nums = { 20, 15, 31, 34, 35, 40, 50, 90, 99, 100 };
    
    	var numsLookup = nums.ToLookup(k => k, k => nums.Where(n => n < k))
    		.Select(k => new KeyValuePair<int, double>
    			(k.Key, 100 * ((double)k.First().Count() / (double)nums.Length)));
    
    	Console.WriteLine("\tKey\t\tValue");
    	Console.WriteLine("================");
    	foreach (var item in numsLookup)
    	{
    		Console.WriteLine("{0}\t\t {1}", item.Key, item.Value);
    	}
    
    
    	Console.Read();
    }
