	int FindPrimes(int NumberOfPrimesToFind)
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
		return NumberOfPrimes ;
	}
