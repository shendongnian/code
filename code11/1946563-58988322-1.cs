    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		// Initialize array with elements from 0 - 1000
    		int[] array = new int[1001];
    		for (int i = 0; i < array.Length; i++) 
    		{
    			array[i] = i;
    		}
    		
    		// Print the elements that are divisible by 5
    		foreach (int a in array)
    		{
    			if (a % 5 == 0)
    			{
    				Console.WriteLine(a);
    			}
    		}
    		
    		// One liner using Linq
    		Enumerable.Range(0, 1001).Where(i => i % 5 == 0).ToList().ForEach(Console.WriteLine);
    	}
    }
