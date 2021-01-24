    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		string mode = null;
    		string abc = (mode ?? "BIG").ToLower(); 
    		if (abc == "cs")  // abc is "big" here
    		{
    			Console.WriteLine("not null");
    		}
    
    		Console.WriteLine(abc);
    	}
    }
