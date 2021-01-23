	// originally was thinking about setting to -1 here and checking the value
	// in each thread when returning from the function, and the last thread to
	// return would then call the invoke to update the text, but it just seemed
	// overly complicated to start pulling out a ResetEvent or Mutex when it could 
	// be handled the wait I have it now.
	int currentCount;
	int allowedCount;
	// so I just did a quick and dirty clock-based delay on both the functions
	// here; nothing magicaly, just wanted to show what I was testing with.
	int Func1()
	{
		DateTime StartTime = DateTime.Now;
		while ((DateTime.Now - StartTime) < TimeSpan.FromSeconds(5))
			System.Threading.Thread.Sleep(100);
		return 32;
	}
	int Func2()
	{
		DateTime StartTime = DateTime.Now;
		while ((DateTime.Now - StartTime) < TimeSpan.FromSeconds(5))
			System.Threading.Thread.Sleep(100);
		return 42;
	}
