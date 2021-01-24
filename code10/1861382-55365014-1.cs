		// Get all the `keys` in the location output
		var keys = GetKeys(locationOutputDistinct);
		// Get the possible combinations of keys
		var combinations = GetCombination(keys);
		
		var maxCombos = new List<string>();
		
		foreach (var combo in combinations)
		{
			var maxOfCombo = GetMaxOfCombo(locationOutputDistinct, combo);
			if(!string.IsNullOrEmpty(maxOfCombo)){
				maxCombos.Add(maxOfCombo);
			}
		}
		maxCombos = maxCombos.Distinct().ToList();
		
		foreach (var maxCombo in maxCombos)
		{
			Console.WriteLine(maxCombo);
		}
