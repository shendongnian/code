csharp
using System;
					
public class Program
{
	public static void Main()
	{
		var v = "Hello my name is {person.firstname} and my house is in {city.name}"
			.Replace("{person.firstname}", "Jim")
			.Replace("{city.name}", "Mexico City");
		
		Console.WriteLine(v);
	}
}
It results in:
> Hello my name is Jim and my house is in Mexico City
