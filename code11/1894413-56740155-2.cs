using System;
					
public class Program
{
	public static bool A(){
		Console.WriteLine("A");
		return true;
	}
	public static bool B(){
		Console.WriteLine("B");
		return true;
	}
	public static void Main()
	{
		if(A() | B())
		Console.WriteLine("Hello World");
	}
}
// Output:
// A
// B
// Hello World
You can run with [.NET Fiddle](https://dotnetfiddle.net/Widget/2Nd47r).
