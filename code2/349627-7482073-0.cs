	using System;
	using System.Collections.Generic;
	using System.Linq;
	class C
	{
		public static void Main()
		{
			var a = new List<string> {
				"First", "Second", "Third"
			};
			System.Console.Write(string.Join(",", a));
		}
	}
