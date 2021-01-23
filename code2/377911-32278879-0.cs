    using System;
    using System.Linq.Expressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Test(s => s.StartsWith("A"));
    	}
    	
    	static void Test(Expression<Func<string,bool>> expr)
    	{
    		Console.WriteLine(expr.ToString());
    		Console.ReadKey();
    	}
    }
