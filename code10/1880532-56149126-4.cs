	static void Main(string[] args)
	{
		RecursiveTriangle(5);         
		Console.ReadLine();
	}
	static void RecursiveTriangle(int width)
	{
		if (width > 0)
		{
			string row = new string('*', width);
			Console.WriteLine(row);
			RecursiveTriangle(--width);
			Console.WriteLine(row);
		}
	}
