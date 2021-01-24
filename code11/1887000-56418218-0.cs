using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{	
		var l = List();
		Console.WriteLine("Type of enumerable returned by List(): " + l.GetType().FullName);
		Console.WriteLine(l + "wtf"); 
	}
										
	public static IEnumerable<string> List() {
		yield return "abc";
		yield return "xyz";
	}
}
(https://dotnetfiddle.net/H0hl4O)
Assuming, the type name of the compiler-generated enumerable object returned by _List()_ is "_Program+<List>d\_\_0_", this example would produce the following output:
    Type of enumerable returned by List(): Program+<List>d__0
    Program+<List>d__0wtf
