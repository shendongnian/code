cs
Method(TheVoid()); // does not compile
Method(TheVoid); // compiles
cs
using System;
public class Example
{
	
	public void Method(Action func)
	{
		func();
	}
	
	public void TheVoid()
	{
		Console.WriteLine("In example.TheVoid");	
	}
}
					
public class Program
{
	public static void TheVoid()
	{
		Console.WriteLine("In TheVoid");
	}
	public static void Main()
	{
		var example = new Example();
		example.Method(example.TheVoid);
		example.Method(() => {
		   Console.WriteLine("In lambda");
		});
		example.Method(TheVoid);
	}
}
Example of what you are trying to do
