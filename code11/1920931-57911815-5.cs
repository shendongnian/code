	var text = "other";
	var keysHavingText = new List<string>();
	
	using (var resx = new ResXResourceReader(resxPath)) 
		foreach(DictionaryEntry entry in resx)
			if(entry.Value.ToString().Contains(text))
				keysHavingText.Add(entry.Key.ToString());
	
	Console.WriteLine(string.Join(",",keysHavingText)); // res2,res3
