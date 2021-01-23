	public IEnumerable<T> AllCombinations<T>() where T : struct
	{
		var type = typeof(T);
		if (!type.IsEnum)
		{
			throw new ArgumentException($"Type parameter '{nameof(T)}' must be an Enum type.");
		}
		for (var combination = 0; combination < Enum.GetValues(type).Cast<int>().Max()*2; combination++)
		{
			var result = (T)Enum.ToObject(type, combination);
			// Optional check for legal combination.
			// (and is not necessary if all flag a ascending exponent of 2 like 2, 4, 8...
			if (result.ToString() == combination.ToString() && combination != 0)
			{
				continue;
			}
			yield return result;
		}
	}
