    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var test = new Test();
    
    		Console.WriteLine(test == null);
    		Console.WriteLine(test is null);
    	}
    	
    	public class Test
    	{
    		public static bool operator ==(Test a, Test b)
    		{
    			Console.WriteLine("==");
    			return ReferenceEquals(a, b);
    		}
    
    		public static bool operator !=(Test a, Test b)
    		{
    			Console.WriteLine("!=");
    			return !ReferenceEquals(a, b);
    		}
    	}
    }
