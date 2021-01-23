    Try this
    
     var URLs = new[] 
    		{ 
    			"http://www.google.com", 
    			"http://www.microsoft.com", 
    			"http://www.slashdot.org"
    		};
    
    		var tasks = URLs
    			.Select(url => Task.Factory.StartNew(
    				task => 
    				{
    					using (var client = new WebClient())
    					{
    						var t = (string)task;
    						Stopwatch stopwatch = new Stopwatch();
    						stopwatch.Start();
    						String result = client.DownloadString(t);
    						stopwatch.Stop();
    						Console.WriteLine(String.Format("{0} = {1}", url, stopwatch.Elapsed));
    
    					}
    				}, url)
    			)
    			.ToArray();
    
    		Task.WaitAll(tasks);
