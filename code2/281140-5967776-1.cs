	class Example
	{
		public static void Main()
		{
			var comparisonTypePerformed =
				GetComparisonTypePerformed(
					new TestedMethod(string.IndexOf));
			
			Console.WriteLine("Comparison type performed was: " + comparisonTypePerformed);
		}
		
		public static StringComparison GetComparisonTypePerformed(TestedMethod testedMethod)
		{
			StringComparison comparisonTypePerformed;
			var prevCulture = Thread.CurrentThread.CurrentCulture;
			try
			{
				Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
				// Check if method performs an Ordinal search
				int result = testedMethod("œ", "oe", 0, 1, comparisonType);
				
				if (result == StringHelper.NPOS)
				{
					// Check if method performs a case-sensitive search
					result = testedMethod("a", "A", 0, 1, comparisonType);
					
					if (result == StringHelper.NPOS)
						comparisonTypePerformed = StringComparison.Ordinal;
					else
						comparisonTypePerformed = StringComparison.OrdinalIgnoreCase;
				}
				else
				{
					Thread.CurrentThread.CurrentCulture = new CultureInfo("sq-AL", false);
					// Check if method uses CurrentCulture or InvariantCulture
					result = testedMethod("ll", new string[] { "l" }, 0, 2, comparisonType);
					
					if (result == StringHelper.NPOS)
					{
						// Check if method performs a case-sensitive search
						result = testedMethod("a", new string[] { "A" }, 0, 1, comparisonType);
						
						if (result == StringHelper.NPOS)
							comparisonTypePerformed = StringComparison.CurrentCulture;
						else
							comparisonTypePerformed = StringComparison.CurrentCultureIgnoreCase;
					}
					else
					{
						// Check if method performs a case-sensitive search
						result = testedMethod("a", new string[] { "A" }, 0, 1, comparisonType);
						
						if (result == StringHelper.NPOS)
							comparisonTypePerformed = StringComparison.InvariantCulture;
						else
							comparisonTypePerformed = StringComparison.InvariantCultureIgnoreCase;
					}
				}
			}
			finally
			{
				Thread.CurrentThread.CurrentCulture = prevCulture;
			}
			return comparisonTypePerformed;
		}
		
		delegate int TestedMethod(string source, string value, int startIndex, int count, StringComparison comparisonType);
	}
