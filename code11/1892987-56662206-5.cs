using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		// at this point unique numbers have been generated and inputted
		int[] numbers = { 1, 2, 3, 4, 5, 6 };
		int[] guesses = { 2, 6, 7, 8, 9, 10 };
		
		List<int> matches = new List<int>(numbers.Intersect(guesses));
		foreach (int n in matches)
		{
			Console.WriteLine("Hit: " + n.ToString());
		}
	}
}
Using a single `for` loop and checking with the [`Contains`][2] method (Array implements the IList interface) if the other array contains the number at the current index. You could also use a `foreach` loop, since you don't care about the indexes.
using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		// at this point unique numbers have been generated and inputted
		int[] numbers = { 1, 2, 3, 4, 5, 6 };
		int[] guesses = { 2, 6, 7, 8, 9, 10 };
		List<int> matches = new List<int>();
		
		for (int i = 0; i < guesses.Length; i++)
		{
			if (numbers.Contains(guesses[i]))
			{
				Console.WriteLine("Hit: " + guesses[i].ToString());
				matches.Add(guesses[i]);
			}
		}
	}
}
Of you could use a nested `for` loops, one for each array, to check each number from one array against every number of the other one.  
Again you could use `foreach` loops.
using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		// at this point unique numbers have been generated and inputted
		int[] numbers = { 1, 2, 3, 4, 5, 6 };
		int[] guesses = { 2, 6, 7, 8, 9, 10 };
		List<int> matches = new List<int>();
		
		for (int i = 0; i < guesses.Length; i++)
		{
			for (int j = 0; j < numbers.Length; j++)
			{
				if (guesses[i] == numbers[j])
				{
					Console.WriteLine("Hit: " + guesses[i].ToString());
					matches.Add(guesses[i]);
					break; // optional, we found the number and can leave the loop. Not optional if your lottery allows numbers to happen more than once.
				}
			}
		}
	}
}
As for the question why your code isn't working:  
You set `j = 0` when `j == 5` just after `j++`, meaning you set `j` to 0 after checking index 4. While I do not want to encourage such unorthodox styles you could fix it by comparing `j == 6`. Again, this approach makes your code unreadable, please use one of the other solutions.
using System;
					
public class Program
{
	public static void Main()
	{
		// at this point unique numbers have been generated and inputted
		int[] numbers = { 1, 2, 3, 4, 5, 6 };
		int[] guesses = { 2, 6, 7, 8, 9, 10 };
		
		int[] winning = new int[6];
		int w = 0;
		var x = 0;
		var j = 0;
		while (x < 6)
		{
			if (guesses[j] == numbers[x])
			{
				winning[w] = numbers[x];
				Console.WriteLine(winning[w]);
				w++;
			}
			j++;
			if (j == 6)
			{
				x++;
				j = 0;
			}
		}
	}
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.intersect
  [2]: https://docs.microsoft.com/de-de/dotnet/api/system.array.system-collections-ilist-contains
