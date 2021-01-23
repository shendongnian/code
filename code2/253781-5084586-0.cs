        int workCount = 0;
    	var timer = new System.Timers.Timer(1800000);	// every half hour
    	timer.AutoReset = true;
    	
    	timer.Elapsed += (src, e) =>
    	{
    		Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
    		
    		if(++workCount == 48)
    		{
    			timer.Stop();
    		}
    	};
    	
    	timer.Start();
