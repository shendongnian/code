	public static IEnumerable<int> FilterDigits(IEnumerable<int> numbers, byte digit)
	{
		if (numbers == null)
		{
			throw new ArgumentNullException();
		}
		return FilterDigitsImpl(numbers, digit);
	}
	private static IEnumerable<int> FilterDigitsImpl(IEnumerable<int> numbers, byte digit)
	{
		foreach (int number in numbers)
		{
			if (number.ContainsDigit(digit))
			{
				yield return number;
			}
		}
	}
