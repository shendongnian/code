	public static List<string> GetKeys(List<string> vals)
	{
		var keys = new List<string>();
		foreach (var grouping in vals)
		{
			var parameters = grouping.Split(' ');
			foreach (var parameter in parameters)
			{
				var paramVals = parameter.Split(':');
				var label = paramVals[0].Trim();
				if (!string.IsNullOrEmpty(label) && !keys.Contains(label))
				{
					keys.Add(label);
				}
			}
		}
		return keys;
	}
	public static List<string> GetCombination(List<string> list)
	{
		var combos = new List<string>();
		var comb = "";
		double count = Math.Pow(2, list.Count);
		for (int i = 1; i <= count - 1; i++)
		{
			var sep = "";
			string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
			for (int j = 0; j < str.Length; j++)
			{
				if (str[j] == '1')
				{
					comb += sep + list[j];
					sep = ";";
				}
			}
			combos.Add(comb);
			comb = "";
		}
		return combos;
	}
	public static string GetMaxOfCombo(List<string> source, string combo)
	{
		var comboKeys = combo.Split(';');
		var matchingCombos = source.Where(s => comboKeys.All(a => s.IndexOf(a) != -1) && s.Trim().Split(' ').Length == comboKeys.Count());
		var comboValues = matchingCombos.Select(mc => new
		{
			// Get the value sum of the individual keys
			value = mc.Split(' ').Where(w => !string.IsNullOrEmpty(w.Trim())).Sum(s => int.Parse(string.Concat(s.Where(c => char.IsDigit(c))))), 
			label = mc
		});
		var max = comboValues.FirstOrDefault(f => f.value == comboValues.Max(m => m.value));
		if (max == null) // This combination didn't exist.
		{
			return "";
		}
		return max.label;
	}
