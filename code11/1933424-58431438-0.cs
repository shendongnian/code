class A
	{
		public string P1 { get;	set; } = "Hello!";
	}
	
	public static void Main()
	{
		M1(new List<A>(){new A()});
		M1(new List<A>());
	}
	static void M1(List<A> l)
	{
		if(l.FirstOrDefault(a => a != null) is var x && x != null) {
				Console.WriteLine(x.P1);
		}
		else {
				Console.WriteLine("null");
		}
	}
Hello!
null
