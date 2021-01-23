	/// <summary>
	/// Converts dictionary to 2d string array
	/// </summary>
	/// <param name="Dictionary">Dictionary to be converted</param>
	/// <returns>2D string Array</returns>
	private string[,] ConvertDictionaryTo2dStringArray(Dictionary<string, string> Dictionary)
	{
		string[,] stringArray2d = new string[2, Dictionary.Count];
		int i = 0;
		foreach (KeyValuePair<string, string> item in Dictionary)
		{
			stringArray2d[0, i] = item.Key;
			stringArray2d[1, i] = item.Value;
			i++;
		}
		return stringArray2d;
	}
