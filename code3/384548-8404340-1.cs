    var sample = "sample";
    for (var i = 0; i < 10; i++)
    {
	    var clock = new Stopwatch();
	    clock.Start();
	    for (var j = 0; j < 10000000; j++)
	    {
		    var first = sample.Substring(0, 1);
	    }
	    clock.Stop();
	    Console.Write(clock.Elapsed);
    }
    // Results
    00:00:00.3268155
    00:00:00.3337077
    00:00:00.3439908
    00:00:00.3273090
    00:00:00.3380794
    00:00:00.3400650
    00:00:00.3280275
    00:00:00.3333719
    00:00:00.3295982
    00:00:00.3368425
