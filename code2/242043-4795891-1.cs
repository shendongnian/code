    void Main()
    {
    	var test = new Test();
    	var mi = test.GetType().GetMethod("Hello");
    	InvokeOnNewThread(mi, test, GetResult);
    	
    	
    	Thread.Sleep(1000);
    }
    
    public void GetResult(object obj) 
    {
    	Console.WriteLine(obj);
    }
