    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
        	Console.Write("Enter integer value: ");
        	int intVal = Convert.ToInt32(Console.ReadLine());
        	Console.WriteLine("You entered: {0} (In binary this number is: {1})", intVal, Convert.ToString(intVal, 2));
    		Console.WriteLine("{0} | 4 (100 in binary) = {1} (In binary this number is: {2})", intVal, intVal | 4, Convert.ToString(intVal | 4, 2));
    	}
    }
