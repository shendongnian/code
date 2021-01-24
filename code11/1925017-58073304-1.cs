cs
private static string InputFields = "";
and use `InputFields += ".";` for example.
Also note that `xxx.Replace(...)` doesn't actually do anything here because you are not assigning the result of this method to anything. You can drop it altogether.
----
As per @CinCout's comment, are you able to verify the value of `xxx`?
I tried the example above and it should work with the `test` input:
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
