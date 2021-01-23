    var sample = "sample";
    for (var i = 0; i < 10; i++)
    {
	    var clock = new Stopwatch();
	    clock.Start();
	    for (var j = 0; j < 10000000; j++)
	    {
		    var first = sample[0].ToString();
	    }
	    clock.Stop();
	    Console.Write(clock.Elapsed);
    }
    
    // Results
    00:00:00.2012243
    00:00:00.2207168
    00:00:00.2184807
    00:00:00.2258847
    00:00:00.2296456
    00:00:00.2261465
    00:00:00.2120131
    00:00:00.2221702
    00:00:00.2346083
    00:00:00.2330840
