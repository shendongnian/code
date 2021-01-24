    public static void Main()
	{
		Console.WriteLine("test 0 | " + NumberSuffix(0));  // 0th
		Console.WriteLine("test 1 | " + NumberSuffix(1));  // 1st
		Console.WriteLine("test 2 | " + NumberSuffix(2));  // 2nd
		Console.WriteLine("test 3 | " + NumberSuffix(3));  // 3rd
		Console.WriteLine("test 4 | " + NumberSuffix(4));  // 4th
		Console.WriteLine("test 10| " + NumberSuffix(10)); // 10th
	}
	
		public static string NumberSuffix(int n)
		{
			//                           0     1     2     3     4     5     6     7     8     9      10    11    12
			string[] nth = new string[] {"th", "st", "nd", "rd", "th", "th", "th", "th", "th", "th", "th", "th", "th"};
			int n2 = Math.Abs(n);
			
			int n1 = n2 - ((n2 / 100) * 100);
			if (n1 > 13) return n + nth[n2 % 10];
			return n + nth[n1 % 13];
		}
