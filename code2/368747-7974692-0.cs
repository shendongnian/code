    static ConcurrentDictionary<DateTime, object> cacheAccess = new ConcurrentDictionary<DateTime, object>();
    static ConcurrentDictionary<DateTime, int> cacheData = new ConcurrentDictionary<DateTime, int>();
    
    static int GetValue(DateTime key)
    {
    	var accessLock = cacheAccess.GetOrAdd(key, x =>  new object());
    
    	lock (accessLock)
    	{
    		int resultValue;
    		if (!cacheData.TryGetValue(key, out resultValue))
    		{
    			Console.WriteLine("Generating {0}", key);
    			Thread.Sleep(5000);
    			resultValue = (int)DateTime.Now.Ticks;
    			if (!cacheData.TryAdd(key, resultValue))
    			{
    				throw new InvalidOperationException("How can something else have added inside this lock?");
    			}
    		}
    
    		return resultValue;
    	}
    }
    
    
    static void Main(string[] args)
    {
    	var keys = new[]{ DateTime.Now.Date, DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(2)};
    	var rand = new Random();
    
    	Parallel.For(0, 1000, (index) =>
    		{
    			var key = keys[rand.Next(keys.Length)];
    
    			var value = GetValue(key);
    
    			Console.WriteLine("Got {0} for key {1}", value, key);
    		});
    }
