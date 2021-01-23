    public void Test_IsRegex_Performance()
    {
    	Action withRegexMatch = () =>
    	{
    		Regex regex = new Regex("^[0-9a-f]{32}$");
    		Guid g = new Guid();
    		string s = g.ToString();
    		regex.IsMatch(s);
    	};
    
    	Action withCharCheck = () =>
    	{
    		Guid g = new Guid();
    		string s = g.ToString();
    
    		Func<char, bool> charValid = c => (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f');
    		bool isValid = s.Length == 32 && s.All(charValid);
    	};
    
    	Action withNewGuid = () =>
    	{
    		Guid g = new Guid();
    		string s = g.ToString();
    		try
    		{
    			Guid g2 = new Guid(s);
    			// if no exception is thrown, this is a valid string 
    			// representation
    		}
    		catch
    		{
    			// if an exception was thrown, this is an invalid
    			// string representation
    		}
    	};
    
    	const int times = 100000;
    
    	Console.WriteLine("Regex: {0}", TimedTask(withRegexMatch, times));
    	Console.WriteLine("Checking chars: {0}", TimedTask(withCharCheck, times));
    	Console.WriteLine("New Guid: {0}", TimedTask(withNewGuid, times));
    	Assert.Fail();
    }
    
    private static TimeSpan TimedTask(Action action, int times)
    {
    	Stopwatch timer = new Stopwatch();
    	timer.Start();
    	for (int i = 0; i < times; i++)
    	{
    		action();
    	}
    	timer.Stop();
    	return timer.Elapsed;
    }
