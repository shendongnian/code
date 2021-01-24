	using System;
	using System.Collections.Generic;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var nums = new List<int>{523, 125, 428, 625};
			var names = new List<string>{"toto", "gaga", "zaza", "dudu"};
            // create combined tuples using Select with index, using _Zip_is more elegant
			var combined = nums.Select((n, i) => new
			{
  			    num = n, name = names[i]
			}
			).OrderByDescending(tup => tup.num);
			foreach (var c in combined)
				Console.WriteLine(string.Format("{0} {1}", c.num, c.name));
		}
	}
