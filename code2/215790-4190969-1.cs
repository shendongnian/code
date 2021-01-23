    class Program
    {
    	static void Main(string[] args)
    	{
    		Task task1 = Task.Factory.StartNew(() => doStuff());
    		Task task2 = Task.Factory.StartNew(() => doStuff());
    		Task task3 = Task.Factory.StartNew(() => doStuff());
    		Task.WaitAll(task1, task2, task3);
                    Console.WriteLine("All threads complete");
    	}
    
    	static void doStuff()
    	{
    		//do stuff here
    	}
    }
    
