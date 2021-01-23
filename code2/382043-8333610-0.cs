	// A utility class that holds math utility functions.
	public static class MathUtility
	{
		// This method returns the fibonacci sequence which is an 
		// infinite sequence of numbers where each result is the
		// sum of the previous two results.
		public static IEnumerable<int> GetFibonacciSequence()
		{
			int first = 0;
			int second = 1;
			// first and second result are always 1.
			yield return first;
			yield return second;
			// this enumerable sequence is bounded by the caller.
			while(true)
			{
				int current = first + second;
				yield return current;
				// wind up for next number if we're requesting one
				first = second;
				second = current;
			}
		}
	}
