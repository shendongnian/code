	public static void Main(String[] args)
	{
		int i = 92;
		Log(string.Format("{0} became {1}", i++, i));
		Console.WriteLine(i);
		Console.ReadLine();
	}
	[Conditional("SKIP")]
	private static void Log(string msg)
	{
		Console.WriteLine(msg);
	}
