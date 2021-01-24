	public static int EnterIntengerNumber()
	{
		return EnterNumber(t => int.TryParse(t, out int v) ? (int?)v : null)
	}
	
	public static double EnterRealNumber()
	{
		return EnterNumber(t => double.TryParse(t, out double v) ? (double?)v : null)
	}
	
	private static T EnterNumber<T>(Func<string, T?> tryParse) where T : struct
	{
		while (true)
		{
			Console.Write("Enter a number: ");
			T? result = tryParse(Console.ReadLine());
			if (result.HasValue)
			{
				return result.Value;
			}
			else
			{
				ConsoleError("Incorrect value");
			}
		}
	}
