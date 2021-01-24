	using System;
	using System.Linq;
	using System.Collections.Generic;
	public class Program
	{
		public static void Main()
		{
			var test1 = new [] {1, 2, 3};
			var test2 = new [] {2, 3, 1};
			var test3 = new [] {3, 1, 2};
			var test4 = new [] {2, 1, 3};
			test1.IsCiruclarPermutation(test2);
			test1.IsCiruclarPermutation(test3);
			test2.IsCiruclarPermutation(test1);
			test2.IsCiruclarPermutation(test3);
			test3.IsCiruclarPermutation(test1);
			test3.IsCiruclarPermutation(test2);
			test4.IsCiruclarPermutation(test1);
			test4.IsCiruclarPermutation(test2);
			test4.IsCiruclarPermutation(test3);
		}
	}
	public static class ArrayExtensions
	{
		public static bool IsCiruclarPermutation(this int[] source, int[] dest)
		{
			Console.Write(string.Join(",", source) + " is a Ciruclar Permutation of ");
			Console.Write(string.Join(",", dest));
			var left = source.ToList();
			var right = dest.ToList();
			right.AddRange(dest);
			var result = false;
			for (int idx = 0; idx < left.Count; idx++)		
			{
				var compareTo = right.Skip(idx).Take(left.Count);
				result = Enumerable.SequenceEqual(left, compareTo);
				if (result) break;
			}
			Console.WriteLine("  " + result.ToString());
			return result;
		}
	}
