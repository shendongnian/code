	class DoubleExtensions
	{
		public double ParseToDouble(this string strValue)
		{			
			// Create a NumberFormatInfo object
			NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
			
			// Store the current value to restore it later
			var currentSeperator = nfi.NumberDecimalSeparator;
			
			// Change the seperator and parse the value
			nfi.NumberDecimalSeparator = ",";
			
			try
			{
				if (double.TryParse(strValue, nfi, out var value))
				{
					return value;
				}			
			}
			finally
			{
				// Restore the separator
				nfi.NumberDecimalSeparator = currentSeperator;
			}
			
			return 0;
		}
	}
	
