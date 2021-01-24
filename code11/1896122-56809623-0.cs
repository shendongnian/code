	static System.Globalization.CultureInfo DateTimeProvider = System.Globalization.CultureInfo.InvariantCulture;
	const System.Globalization.DateTimeStyles ParseExactStyle = System.Globalization.DateTimeStyles.None;
	static DateTime[] DateSamples = new[]
		{
			DateTime.Now,
			DateTime.Today,
			DateTime.Today.AddDays(1 - DateTime.Today.Day),
			DateTime.Parse("10-Jan-2000"),
			DateTime.Parse("01-Oct-1990"),
			DateTime.Parse("13-Feb-1901")
		};
	
	public static bool IsValidDateFormat(string format, out string result)
	{
		var maxDifference = TimeSpan.FromDays(1);
		foreach (var sample in DateSamples)
		{		
			// Rule 1: Must be suitable for '.ToString(...)'
			string sampleString;
			try
			{
				sampleString = sample.ToString(format);
			}
			catch (FormatException e)
			{
				result = $"Failed rule 1: {e.Message}";
				return false;
			}
			
			// Rule 2: Must be able to parse the produced string
			if (!DateTime.TryParseExact(sampleString, format, DateTimeProvider, ParseExactStyle, out var parsed))
			{
				result = $"Failed rule 2: does not parse it's own output. '{sampleString}'";
				return false;
			}
			
			// Rule 3: No time values.
			if (parsed != parsed.Date)
			{
				result = $"Failed rule 3: No time values. '{sampleString}' => #{parsed}#";
				return false;
			}
			
			// Rule 4: Difference must be less than maxDifference
			TimeSpan difference = sample < parsed ? parsed - sample : sample - parsed;
			if (difference >= maxDifference)
			{
				result = $"Failed rule 4: difference '{difference}' too large.";
				return false;
			}
		}
		
		result = "OK";
		return true;
	}
