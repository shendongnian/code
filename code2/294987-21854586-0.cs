	class Program
	{
		public static int x; // public static field. 
							 // this way the JITer will not assume that it is  
							 // never used and optimize the wholeloop away
		static void Main()
		{
			// warm up
			for (int i = -1000000000; i < 1000000000; i++)
			{
				x = Math.Abs(i);
			}
			// start measuring
			Stopwatch watch = Stopwatch.StartNew();
			for (int i = -1000000000; i < 1000000000; i++)
			{
				x = Math.Abs(i);
			}
			Console.WriteLine(watch.ElapsedMilliseconds);
			// warm up
			for (int i = -1000000000; i < 1000000000; i++)
			{
				x = i > 0 ? i : -i;
			}
			// start measuring
			watch = Stopwatch.StartNew();
			for (int i = -1000000000; i < 1000000000; i++)
			{
				x = i > 0 ? i : -i;
			}
			Console.WriteLine(watch.ElapsedMilliseconds);
			// warm up
			for (int i = -1000000000; i < 1000000000; i++)
			{
				x = (x + (x >> 31)) ^ (x >> 31);
			}
			// start measuring
			watch = Stopwatch.StartNew();
			for (int i = -1000000000; i < 1000000000; i++)
			{
				x = (x + (x >> 31)) ^ (x >> 31);
			}
			Console.WriteLine(watch.ElapsedMilliseconds);
			Console.ReadLine();
		}
	}
