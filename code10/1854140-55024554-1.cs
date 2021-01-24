    internal static double ToLocalCultureDouble(string input)
		{
			string toConvert = ReplaceWithDecimalSep(input);
			double.TryParse(toConvert, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double result);
			return result;
		}
