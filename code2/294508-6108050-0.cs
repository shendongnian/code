		static void Main(string[] args)
		{
			double[] input = { 1.00, 2.92, -2.92, 3.00, 7.56, -7.56, 8.00, -100.93, -40.56 };
			IEnumerable<int> intsWithouDuplicates = input.Where(d => !input.Contains(-d)).Select(d => (int)(d * 100)).OrderBy(i => i);
			var listA = intsWithouDuplicates.Where(i => i >= 0);
			var listB = intsWithouDuplicates.Where(i => i < 0);
			listA.ToList().ForEach(Console.WriteLine);
			Console.WriteLine();
			listB.ToList().ForEach(Console.WriteLine);
			Console.ReadKey();
		}
