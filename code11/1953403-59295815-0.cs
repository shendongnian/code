	public class EscapeInterceptor : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			// you of course can go way fancier than that. 
			// one thing of note here is that your Property setters would be prefixed with "set_", but nothing stops you from targeting other methods as well
			var prop = invocation.TargetType.GetProperties()
			.FirstOrDefault(p => invocation.Method.Name == $"set_{p.Name}" && p.GetCustomAttribute(typeof(EscapeInvalidAttribute)) != null);
			if (prop != null) { 
				invocation.Arguments[0] = EscapeInvalidAttribute.Escape((string)invocation.Arguments[0]);	
			}		
			invocation.Proceed(); // allow the call to proceed anyway
		}
	}
	public class EscapeInvalidAttribute : Attribute
	{
		public static string Escape(string input)
		{
			return $"escape|{input}|string";
		}
	}
	public class MyClass
	{
		[EscapeInvalid]
		public virtual string Prop1 { get; set; }
	
		public virtual string Prop2 { get; set; }
	
	}
	void Main()
	{
		var generator = new ProxyGenerator();
		MyClass myClassProxy = (MyClass)generator.CreateClassProxy(typeof(MyClass), new[] {new EscapeInterceptor()});
		myClassProxy.Prop1 = "test";
		myClassProxy.Prop2 = "test";
		Console.WriteLine(myClassProxy.Prop1);
		Console.WriteLine(myClassProxy.Prop2);
	}
