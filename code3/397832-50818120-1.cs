    using System;
    using System.Text.RegularExpressions;	
    public class Program
	{
		public static void Main()
		{
			var p1 = "aaaa999999"; 
			CheckMatch(p1);
			p1 = "aaaa9999999";
			CheckMatch(p1);
			p1 = "aaaa99999999";
			CheckMatch(p1);
			p1 = "aaa999999";
			CheckMatch(p1);
		}
	
		public static void CheckMatch(string p1)
		{
			var reg = new Regex(@"^\w{4}\d{6,7}$");
			if (!reg.IsMatch(p1))
			{
				Console.WriteLine($"{p1} doesn't match");
			}
			else
			{
				Console.WriteLine($"{p1} matches");
			}
		}
	}
