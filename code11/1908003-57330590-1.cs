    public static async Task<double> Do()
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
    
        var t1 = Do1();
        var t2 = Do2();
    	
        await t1;
        await t2;
    
        var time = sw.Elapsed.TotalMilliseconds;
    	Console.WriteLine("time="+time); // time=3002.3204
    	return time;
    }
    
    public static async Task Do1()
    {
    	var t = Task.Delay(1000);
    	
    	while(t.Status != TaskStatus.RanToCompletion) {}
    	
    	await t;
    }
    
    public static async Task Do2()
    {
    	var t = Task.Delay(2000);
    	
    	while(t.Status != TaskStatus.RanToCompletion) {}
    	
    	await t;
    }
