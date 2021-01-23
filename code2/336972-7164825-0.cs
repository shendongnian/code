		static void Main(string[] args)
		{
			string userCode = "B";
			char userCodeChar = 'B';
			int iterations = 10000000;
			var sw = Stopwatch.StartNew();
			for (int i = 0; i < iterations; i++)
			{
				if ("AC".IndexOf(userCode) >= 0)
				{
					int a = 1 + 1;
				}
			}
			sw.Stop();
			Console.WriteLine("IndexOf time: {0}ms", sw.ElapsedMilliseconds);
			sw = Stopwatch.StartNew();
			for (int i = 0; i < iterations; i++)
			{
				if ("AC".Contains(userCode))
				{
					int a = 1 + 1;
				}
			}
			sw.Stop();
			Console.WriteLine("Contains time: {0}ms", sw.ElapsedMilliseconds);
			sw = Stopwatch.StartNew();
			for (int i = 0; i < iterations; i++)
			{
				if ("AC".Contains(userCodeChar))
				{
					int a = 1 + 1;
				}
			}
			sw.Stop();
			Console.WriteLine("Contains char time: {0}ms", sw.ElapsedMilliseconds);
			Console.WriteLine("Done");
			Console.ReadLine();
		}
