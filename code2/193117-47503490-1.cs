	private static int b = Foo();
	private static int a = 4;
	private static int Foo()
	{
		Console.WriteLine("{0} - Default initialization", a);
		a = 3;
		Console.WriteLine("{0} - Assignment", a);
		return 0;
	}
	public static void Main()
	{
		Console.WriteLine("{0} - Variable initialization", a);
	}
