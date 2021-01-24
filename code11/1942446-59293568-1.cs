	public class B { }
	public class C { }
	public class A
	{
		public A(B bObject){ Console.WriteLine("I am constructor A typeof(B)");}
		public A(C cObject){ Console.WriteLine("I am constructor A typeof(C)");}	
	}
	
	void Main()
	{
		var builder = new ContainerBuilder();
		builder.RegisterType<A>().UsingConstructor(typeof(B)).Named<A>(nameof(B));
		builder.RegisterType<A>().UsingConstructor(typeof(C)).Named<A>(nameof(C));
		
		//it doesn't really matter if these are registered as you're using nameof() to identify the objects - that's essentially string
		builder.RegisterType<B>();
		builder.RegisterType<C>();
		
		var container = builder.Build();
		
		var a1 = container.ResolveNamed<A>(nameof(B), new TypedParameter(typeof(B), new B()));
		var a2 = container.ResolveNamed<A>(nameof(C), new TypedParameter(typeof(C), new C()));	
	}
