	public static IEnumerable<int> FilterDigits(IEnumerable<int> numbers, byte digit)
	{
		if (numbers == null)
		{
			throw new ArgumentNullException();
		}
		IEnumerable<int> FilterDigitsImpl()
		{
			foreach (int number in numbers)
			{
				if (number.ContainsDigit(digit))
				{
					yield return number;
				}
			}
		}
		return FilterDigitsImpl();
	}
