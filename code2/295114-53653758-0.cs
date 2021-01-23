	public IEnumerable<T> AllCombinations<T>() where T : struct
	{
		var type = typeof(T);
		for (var combination = 0; combination < Enum.GetValues(type).Cast<int>().Max()*2; combination++)
		{
			yield return (T)Enum.ToObject(type, combination);
		}
	}
