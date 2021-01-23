    private readonly Lazy<List<int>> list = new Lazy<List<int>>(() =>
    {
    	List<int> configList = new List<int>(Thread.CurrentThread.ManagedThreadId);
    	return configList;
    });
    public void Execute()
    {
    	list.Value.Add(0);
    	if (list.IsValueCreated)
    	{
    		list.Value.Add(1);
    		list.Value.Add(2);
    
    		foreach (var item in list.Value)
    		{
    			Console.WriteLine(item);
    		}
    	}
    	else
    	{
    		Console.WriteLine("Value not created");
    	}
    }
--> 
output --> 0 1 2 
but if this code dont write "list.Value.Add(0);"
output --> Value not created
