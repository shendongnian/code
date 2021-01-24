	static void Main(string[] args)
	{
		Console.WriteLine("            ^__^");
		Console.WriteLine("            (oo)_______");
		Console.WriteLine("            (__)       )\\");
		Console.WriteLine("                ||---||  ");
		Console.SetBufferSize(1000, Int16.MaxValue - 1);
		for (int i = 0; i < Int16.MaxValue-10; i++)
		{
			Console.WriteLine("                ||   ||");
		}
		Console.SetWindowPosition(0, 0);
		Console.ReadLine();
	}
