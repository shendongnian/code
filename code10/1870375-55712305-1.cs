    dynamic a = new ExpandoObject();
    
    Task task1 = Task.Factory.StartNew(() =>
    {
    	while(true) 
    	{
    		a.Action1 = (Action)(() => { Thread.Sleep(10); });
    		Thread.Sleep(100);
    		((IDictionary<String, Object>)a).Remove("Action1");
    		Thread.Sleep(100);
    	}
    });
    
    Task task2 = Task.Factory.StartNew(() => 
    {
    	while(true)
    	{
    		try 
    		{
    			a.Action1();
    			Console.WriteLine("Action1");
    			Thread.Sleep(20);
    		}
    		catch(Exception e)
    		{
    			Console.WriteLine(e.Message);
    		}
    	}
    });
