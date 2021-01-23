		// input has form "N36102W114383, N36102W114382"
		// output: "N36102", "W114383", "N36102", "W114382", ...
		string[] ParseSequenceString(string input)
		{
		    string[] inputStrings = string.Split(',');
			List<string> outputStrings = new List<string>();
			foreach (string value in inputstrings) {
				List<string> valuesInString = ParseValuesInString(value);
				outputStrings.Add(valuesInString);
			}
			return outputStrings.ToArray();
		}
		// input has form "N36102W114383"
		// output: "N36102", "W114383"
		List<string> ParseValuesInString(string inputString)
		{
			List<string> outputValues = new List<string>(); 
			string currentValue = string.Empty;
			foreach (char c in inputString)
			{
				if (char.IsLetter(c))
				{
					if (currentValue .Length == 0)
					{
						currentValue += c;
					} else
					{
						outputValues.Add(currentValue);
						currentValue = string.Empty;
					}
				}
				currentValue += c;
			}
			outputValues.Add(currentValue);
			return outputValues;
		}
