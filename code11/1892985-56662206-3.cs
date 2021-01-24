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
		List<int> matches1 = new List<int>();
		List<int> matches2 = new List<int>();
		
		// the linq way:
		List<int> matches3 = new List<int>(numbers.Intersect(guesses));
		foreach (int n in matches3)
		{
			Console.WriteLine("Hit: " + n.ToString());
		}
		
		for (int i = 0; i < guesses.Length; i++)
		{
			// The easy way:
			if (numbers.Contains(guesses[i]))
			{
				Console.WriteLine("Hit: " + guesses[i].ToString());
				matches1.Add(guesses[i]);
			}
			// the accademic way:
			for (int j = 0; j < numbers.Length; j++)
			{
				if (guesses[i] == numbers[j])
				{
					Console.WriteLine("Hit: " + guesses[i].ToString());
					matches2.Add(guesses[i]);
					break; // optional
				}
			}
		}
	}
}
You need to compare every number in guesses with every number in numbers. Therefore you need two nested for loops to check each one.
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
