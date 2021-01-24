	List<JsonEntryKey> collection = new List<JsonEntryKey>();
	foreach (var item in items)
	{
		var entry = new JsonEntryKey();
		foreach (var property in item)
		{
			// here the position propInfo[1] has the property name and propInfo[2] has the value
			string [] propInfo = property.Split(new string[] {"].", "="}, StringSplitOptions.RemoveEmptyEntries);
            // extract here the corresponding property information 	
			PropertyInfo info = typeof(JsonEntryKey).GetProperties().Single(x => x.Name == propInfo[1]);
			info.SetValue(entry, Convert.ChangeType(propInfo[2], info.PropertyType));
		}		
		collection.Add(entry);		
	}
