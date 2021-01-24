	public static int arrayMaxConsecutiveSum(int[] inputArray, int k) 
	{
		int sum = 0;
		int max = 0;
		for (int i = 0; i <= inputArray.Length-k; i++)
		{
			// Add the next item
			sum += inputArray[i];
			
			// Limit the sum to k items
			if (i > k) sum -= inputArray[i-k];
            // Is this the highest sum so far?
			if (sum > max)
				max = sum;
		}
		return max;
	}
