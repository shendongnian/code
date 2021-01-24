C#
using System;
using System.Linq;
public class Program
{
	public static void Main()
	{
		string[] Slist = new string[] {"Tom", "Max", "Dick", "Harry"};
		string[] filtered = Slist.Where(n => n == "Tom" || n == "Dick").ToArray();
		
		foreach (string n in filtered) Console.WriteLine(n);
	}
}
will produce the following output
Tom
Dick
https://dotnetfiddle.net/5KL4as
Just a friendly reminder though, try to post more precise questions on Stack Overflow. It's hard to see how this question could **really** help someone else in the future because anyone could just try it in a .NET fiddle or an IDE.
