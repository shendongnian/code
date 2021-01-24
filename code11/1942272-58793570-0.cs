    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var input = Console.ReadLine();
    		// or use a fixed input: var input = "1 2 3 4";
     		int[] arrayPart3 = input.Split(' ',',', ';').Select(s => int.Parse(s)).ToArray();
    													 
    		Console.WriteLine("Reversed: " + string.Join("| ", arrayPart3.Reverse()));
    		Console.WriteLine();
    
    		Console.WriteLine("Largest is:" + arrayPart3.Max());
    		Console.WriteLine("Smallest is:" + arrayPart3.Min());
    		Console.WriteLine("Squared: " + string.Join("| ", arrayPart3.Select(i => i*i)));
    		Console.WriteLine("Reversed Squared: " + string.Join("| ", arrayPart3.Reverse().Select(i => i*i)));
    		
    	}
    }
