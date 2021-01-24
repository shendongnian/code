using System;
using DryIoc;
					
public class Program
{
	public static void Main()
	{
		var container = new Container();
		
		// variant 1
		container.RegisterInstance("1", serviceKey: "x");
		container.RegisterInstance("2", serviceKey: "y");
		container.Register<A>(made: Parameters.Of.Name("x", serviceKey: "x").Name("y", serviceKey: "y"));
		
		// variant 2
		//container.Register<A>(made: Parameters.Of.Name("x", _ => "1").Name("y", _ => "2"));
		
		var a = container.Resolve<A>();
		
		Console.WriteLine(a.X + ", " + a.Y);
	}
	
	public class A 
	{
		public string X, Y;
		public A(string x, string y) 
		{
			X = x;
			Y = y;
		}
	}
}
