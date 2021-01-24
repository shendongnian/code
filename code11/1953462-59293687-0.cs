using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine(DateTime.ParseExact("20191211202600", "yyyyMMddHHmmss", null));
	}
}
Output is:
12/11/2019 8:26:00 PM
