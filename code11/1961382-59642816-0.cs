	using System;
						
	public class Program
	{
		public static void Main()
		{
			var genericArguments = typeof(A<>).GetGenericArguments();
			var attributes = Attribute.GetCustomAttributes(genericArguments[0]);
			Console.WriteLine((attributes[0] as MyAttribute).Name);
		}
	}
	[AttributeUsage(AttributeTargets.GenericParameter)]
	class MyAttribute : Attribute
	{
		public string Name;
	}
	class A<[MyAttribute(Name = "MyAttributeValue")] Type>
	{
	}
