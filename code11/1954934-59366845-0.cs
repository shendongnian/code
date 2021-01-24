    public void GetData()
    {      
		List<PairedValues> pairedValues = new List<PairedValues>(); 
    	
		foreach (var f in dict1)
		{
			var fileName = f.Key;
			var startTime = DateTime.Parse(f.Value);
			if (dict2.ContainsKey(f.Key))
			{
				endTime = DateTime.Parse(dict2[f.Key]);
				pairedValues.Add(new PairedValues(f.Key, startTime, endTime));
			}
		}
    }
