using System;
using System.Reflection;
					
public class Program
{
	public static void Main()
	{
		Type t = Type.GetType("Second"); //get class name from config here
		 MethodInfo method 
             = t.GetMethod("Hello", BindingFlags.Static | BindingFlags.Public); // get method by name here
		Console.WriteLine(method.Invoke(null,null));
	}
}
public static class First
{
	public static string Hello(){
	return "hello";	
	}
}
public static class Second 
{
	public static string Hello(){
	return "Hello World";	
	}
}
This will allow you to get a class and method defined by names you can get from the config file.
