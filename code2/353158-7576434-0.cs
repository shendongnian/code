    static void Main(string[] args)
    {
    	var col = new BlockingCollection<int>(1);
    
    	Task.Factory.StartNew(
    		() =>
    		{
    			GenerateStuff(col);
    			col.CompleteAdding();
    		});
    
    	while (!col.IsCompleted)
    	{
    		Thread.Sleep(100);
    
    		int result;
    		if (!col.TryTake(out result, -1))
    		{
    			break;
    		}
    		Console.WriteLine("Got {0}", result);
    	}
    
    	Console.WriteLine("Done Adding!");
    }
    
    static void GenerateStuff(BlockingCollection<int> col)
    {
    	for (int i = 0; i < 10; i++)
    	{
    		Thread.Sleep(10);
    		Console.WriteLine("Adding {0}", i);
    		col.Add(i);
    		Console.WriteLine("Added {0}", i);
    	}
    }
