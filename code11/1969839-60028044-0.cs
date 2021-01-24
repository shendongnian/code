    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
    	class Program
    	{
    		static void Main()
    		{
    			// random number generator
    			Random random = new Random();
    
    			// allocate array
    			double[,] matrix = new double[4, 4];
    
    			// possible entries
    			List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
    
    			// loop matrix entries
    			for (int i = 0; i < matrix.GetLength(0); i++)
    			{
    				for (int j = 0; j < matrix.GetLength(1); j++)
    				{
    					int randomNumberIndex = random.Next(0, numbers.Count); // get a random index from the possible numbers list
    					int randomNumber = numbers[randomNumberIndex]; // get the number at the index
    					numbers.RemoveAt(randomNumberIndex); // remove the number from the list
    					matrix[i, j] = randomNumber;
    				}
    			}
    
    			// print matrix
    			for (int i = 0; i < matrix.GetLength(0); i++)
    			{
    				for (int j = 0; j < matrix.GetLength(1); j++)
    				{
    					Console.Write(matrix[i, j] + "\t");
    				}
    				Console.WriteLine();
    			}
    
    			// done
    			Console.Write("Press any key to exit...");
    			Console.ReadKey();
    		}
    	}
    }
