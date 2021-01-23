    	static void Main(string[] args)
		{
			Func<int, int> incr = a => a + 1;
			Console.WriteLine($"P1 = {incr(5)}");
		}
