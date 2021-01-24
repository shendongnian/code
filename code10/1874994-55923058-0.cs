		// Lets try parsing some random strings into doubles.
		// Each one with varying cases.
		string[] testStrings = new string[]{"$32.43", "342", "1,332", "0.93", "123,432.34", "boat"};
		foreach (string ts in testStrings)
		{
			double newValue;
			if (double.TryParse(ts, out newValue))
			{
				// for WPF, you can use a MessageBox or Debug.WriteLine
				Console.WriteLine("We were able to successfully convert '" + ts + "' to a double! Here's what we got: " + newValue);
			}
			else
			{
				// for WPF, you can use a MessageBox or Debug.WriteLine
				Console.WriteLine("We were unable to convert '" + ts + "' to a double");
			}
		}
