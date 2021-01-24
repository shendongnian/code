	static void Main(string[] args)
	{
		RecursiveTriangle(new String('*', 5));
		Console.ReadLine();
	}
	static void RecursiveTriangle(string row)
	{
		if (row.Length > 0)
		{
			Console.WriteLine(row);
			RecursiveTriangle(row.Substring(0, row.Length - 1));
			Console.WriteLine(row);
		}
	}
