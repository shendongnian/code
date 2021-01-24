    dynamic a = new ExpandoObject();
    a.Action1 = (Action)(() => 
    { 
    	Console.WriteLine("Action1 Start"); 
    	Thread.Sleep(1000); 
    	Console.WriteLine("Action1 End");
    });
    
    
    
    Task task1 = Task.Factory.StartNew(() => 
    { 
    	a.Action1(); 
    });
    
    Task task2 = Task.Factory.StartNew(() => 
    { 
    	((IDictionary<String, Object>)a).Remove("Action1");
    	Console.WriteLine("Action1 Removed");
    });
    
    
    Task.WaitAll(task1, task2);
