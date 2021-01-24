c#
	static (int, int) Sqrt2(int n)
	{
		int m = 1, d = 2;
		int dSquared;
		while ((dSquared = d * d) <= n)
		{
			while ((n % dSquared) == 0)
			{
				n /= dSquared;
				m *= d;
			}
			d++;
		}
		return (m, n);
	}
	
	static void Main(string[] args)
	{
		Console.WriteLine(Sqrt2(12)); // prints (2, 3)
		Console.WriteLine(Sqrt2(16)); // prints (4, 1)
		Console.WriteLine(Sqrt2(13)); // prints (1, 13)
	}
