    using System;
    using System.Linq;
    using System.Reflection;
    namespace ConsoleApplication1
    {
	public class CallByAttribute
	{
		[CodeName("Foo")]
		public string MyProperty { get; set; }
		[CodeName("Bar")]
		public string MyMethod(int someParameter)
		{
			return "blah" + someParameter;
		}
	}
	public class CodeNameAttribute : Attribute
	{
		private readonly string name;
		public CodeNameAttribute(string name)
		{
			this.name = name;
		}
		public string Name
		{
			get { return name; }
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			CallByAttribute callByAttribute = new CallByAttribute();
			callByAttribute.MyProperty = "hi";
			Console.WriteLine(Call(callByAttribute, "Bar", new object[] {1}));
			Console.WriteLine(Call(callByAttribute, "Foo"));
			
		}
		private static string Call(object callByAttribute, string name)
		{
			return Call(callByAttribute, name, null);
		}
		private static string Call(object callByAttribute, string name, object[] args)
		{
			PropertyInfo prop = callByAttribute.GetType().GetProperties()
				.Where(p => p.IsDefined(typeof(CodeNameAttribute), false))
                 .SingleOrDefault(p => ((CodeNameAttribute)(p.GetCustomAttributes(typeof(CodeNameAttribute), false)).First()).Name == name);
			if (prop != null)
				return (string)callByAttribute.GetType().InvokeMember(prop.Name, BindingFlags.GetProperty, null, callByAttribute, null);
			MethodInfo method = callByAttribute.GetType().GetMethods()
				.Where(p => p.IsDefined(typeof(CodeNameAttribute), false))
                 .SingleOrDefault(p => ((CodeNameAttribute)(p.GetCustomAttributes(typeof(CodeNameAttribute), false)).First()).Name == name);
			if (method != null)
				return (string)callByAttribute.GetType().InvokeMember(method.Name,  BindingFlags.InvokeMethod, null, callByAttribute, args);
			
			throw new Exception("method/getter not found");
		}
	}
    }
