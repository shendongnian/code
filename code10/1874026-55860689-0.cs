    var obj = new Demo();
    var task1 = obj.WaitForIO(); //Imagine this as a database call that takes 5 seconds to finish
    var task2 = obj.DoSomethingElse(); //Imagine this as some CPU bound work eg: some calculations
    await Task.WhenAll(task1,task2);
    
    public class Demo
    {
    	public async Task WaitForIO()
    	{
    		await Task.Delay(5000); 
    		Console.WriteLine("IO Done");
    	}
    
    	public async Task DoSomethingElse()
    	{
    		for(var i=1;i<10;i++)
    		{
    			Console.WriteLine(i);
    			await Task.Delay(1000);
    		}
    	}
    }
