cs
using System;
using System.Text.RegularExpressions;
					
public class Program
{
	public static void Main()
	{
		var test = "2.3 4.5 6.7";
		var regex = new Regex(@"\d+\.\d+");
		var matches = regex.Matches(test);
		
		foreach (var match in matches)
		{
			Console.WriteLine(match);
		}
	}
}
[Demo](https://dotnetfiddle.net/OZ2qQc)
