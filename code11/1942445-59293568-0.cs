	public class A
	{
		public A(int bObject){	Console.WriteLine("I am constructor A typeof(int)");}
		public A(string cObject){ Console.WriteLine("I am constructor A typeof(object)");}	
	}
	
	void Main()
	{
		var builder = new ContainerBuilder();
		builder.RegisterType<A>().UsingConstructor(typeof(int)).Named<A>("name1");
		builder.RegisterType<A>().UsingConstructor(typeof(string)).Named<A>("name2");
		var container = builder.Build();
		
		var a1 = container.ResolveNamed<A>("name1", new TypedParameter(typeof(int), 1));
		var a2 = container.ResolveNamed<A>("name2", new TypedParameter(typeof(string), "1"));	
	}
