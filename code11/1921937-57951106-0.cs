using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var handlerType = typeof(IHandleKey);
		var classes = typeof(Program).Assembly // you can get them however you want
			.GetTypes()
		    .Where(p => handlerType.IsAssignableFrom(p) && p.IsClass)
			.Select(t => (IHandleKey)Activator.CreateInstance(t)) // or use IoC to resolve them...
			.ToArray();
		
		while(true) {
			var key = Console.ReadLine(); // or however you get your input
			var handler = classes.FirstOrDefault(x => x.Key == key);
			
			if (handler == null) {
				Console.WriteLine("Couldn't find a handler for " + key);
			} else {
				handler.Handle();
			}
		}
	}
}
public interface IHandleKey 
{
	String Key { get; }
	void Handle();	
}
public class Banana : IHandleKey 
{
	public String Key {	get { return "u"; } }
	public void Handle() 
	{
		Console.WriteLine("I did banana work");
	}
}
This way if you need to develop a new feature, all you need to add is one class that contains information about valid key and the implementation logic.
Likewise, if you don't want to have the instances ready to handle the command, you can split this and have an attribute describing the key on the type, like so:
using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var handlerType = typeof(IHandleKey);
		var classes = typeof(Program).Assembly
			.GetTypes()
		    .Where(p => handlerType.IsAssignableFrom(p) && p.IsClass && p.GetCustomAttributes(typeof(KeyHandlerAttribute), false).Count() > 0) // note we're checking for attribute here. This can be optimised.
			.ToArray();
		
		while(true) {
			var key = Console.ReadLine(); // or however you get your input
			var concreteType = classes.FirstOrDefault(x => ((KeyHandlerAttribute)(x.GetCustomAttributes(typeof(KeyHandlerAttribute), false).First())).Key == key);
			
			if (concreteType == null) {
				Console.WriteLine("Couldn't find a handler for " + key);
			} else {
				var handler = (IHandleKey)Activator.CreateInstance(concreteType); // or use IoC to resolve them...
				handler.Handle();
			}
		}
	}
}
public interface IHandleKey 
{
	void Handle();	
}
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class KeyHandlerAttribute: Attribute 
{
	public String Key { get; set; }
}
[KeyHandler(Key = "u")]
public class Banana : IHandleKey 
{
	public void Handle() 
	{
		Console.WriteLine("I did banana work");
	}
}
