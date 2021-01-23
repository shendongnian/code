		public static void Main()
		{
			int[] values = Enumerable.Range(0, 1000000).ToArray();
			int dummy = 0;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int i = 0; i < values.Length; i++)
			{
				dummy *= i;
			}
			stopwatch.Stop();
			Console.WriteLine("Loop took {0}", stopwatch.ElapsedTicks);
			dummy = 0;
			stopwatch.Reset();
			stopwatch.Start();
			foreach (var value in values)
			{
				dummy *= value;			
			}
			stopwatch.Stop();
			Console.WriteLine("Iteration took {0}", stopwatch.ElapsedTicks);
			Console.Read();
		}
