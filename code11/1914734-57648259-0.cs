    using System;
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		Console.WriteLine("Main 1");
    
    		DoSomethingAsync().Wait();
    
    		Console.WriteLine("Main 2");
    	}
    
    	public static async Task DoSomethingAsync()
    	{
    		Console.WriteLine("DoSomethingAsync 1");
    		
    		await Task.Delay(1000);
    		
    		Console.WriteLine("DoSomethingAsync 2");
    	}
    }
