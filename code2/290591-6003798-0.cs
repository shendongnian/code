    MyClass.EventComplete += (result) => Console.WriteLine("Result is: " + result);
    public class MyClass
    {
    	public static Action<double> EventComplete { get; set; }
    
    	public static void MakeSomethingHappen(double[] data)
    	{
    		ThreadPool.QueueUserWorkItem(DoSomething, data);
    	}
    
    	private static void DoSomething(object dblData)
    	{
    		var result = AndSomethingElse((double[])dblData);
    
    		if (EventComplete != null)
    		{
    			EventComplete(result);
    		}
    	}
    
    	public static double AndSomethingElse(double[] data)
    	{
    		//do some code
    		return result; //double
    	}
    }
