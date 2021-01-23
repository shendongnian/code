	static void Main()
	{
		const int NumberOfPrimesToFind = 100000;
		const int NumberOfRuns = 1;
		System.Diagnostic.Stopwatch sw = new System.Diagnostic.Stopwatch();
		
		sw.Start();
		for (int k = 0; k < NumberOfRuns; k++)
		{
			FindPrimes(NumberOfPrimesToFind);
		}
		sw.Stop();
		Console.WriteLine(sw.Elapsed.TotalMilliseconds);
		Console.ReadLine();
	}
	static void FindPrimes(int NumberOfPrimesToFind)
	{
		int NumberOfPrimes = 0;
		int CurrentPossible = 2;
		while (NumberOfPrimes < NumberOfPrimesToFind)
		{
			int IsPrime = 1;
			for (int j = 2; j < CurrentPossible; j++)
			{
				if (CurrentPossible % j == 0)
				{
					IsPrime = 0;
					break;
				}
			}
			NumberOfPrimes += IsPrime;
			CurrentPossible++;
		}
	}
