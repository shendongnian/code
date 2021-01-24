    using System;				
    public class Program
    {
    	public static void Main()
    	{
    		foreach(int x in System.Linq.Enumerable.Range(-5, 10))
    		{
    			int count = x;
    			bool y = count == 0 && (0 == count++ - count++);
    			Console.WriteLine(count);
    		}
    	}
    }
