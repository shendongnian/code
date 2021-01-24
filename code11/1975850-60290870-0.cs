    if (row is IDictionary<string, object>)
	{
		var rowDictionary = row as IDictionary<string, object>;					
		var emptyNames = rowDictionary.Where(x => string.IsNullOrEmpty(x.Key)).ToList();			
		while(rowDictionary.ContainsKey(""))
			rowDictionary.Remove("");
		while(rowDictionary.ContainsKey(null))
			rowDictionary.Remove(null);
		for (var i = 0; i < emptyNames.Count; ++i)
		{
			var kv = emptyNames[i];
			rowDictionary.Add($"(No Column <{i+1}>)", kv.Value);
		}			
	}
