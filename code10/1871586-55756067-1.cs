    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		List<int> factors = new List<int>();
    		while (true)
    		{
    			Console.WriteLine("Please enter an integer: ");
    			var userInput = Console.ReadLine();
    			if (userInput.Equals("quit"))
    				break;
    			if (!Int32.TryParse(userInput, out var firstOut)
                   || !Int32.TryParse(userInput, out var secondOut))
                    continue; 
    			
    			if (firstOut % 2 != 0 || firstOut < 0)
    				continue;
    			while (secondOut % 2 == 0)
    			{
    				secondOut /= 2;
    				factors.Add(secondOut);
    			}
    
    			Console.WriteLine($"{firstOut} has factors: {String.Join(", ", factors)}");
    			factors.Clear();
    		}
    	}
    } 
