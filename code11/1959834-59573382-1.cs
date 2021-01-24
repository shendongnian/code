    var regex = new Regex(Regex.Escape("*"));
	var jo = JObject.Parse(response);
	
	var count = jo.SelectTokens("Results[*].Make_ID").Count();
    // Parse the Json to form collections of KeyValuePairs
	var dataCollection = Enumerable.Range(0,count)
								   .Select(x=>config.Property
								   .Select(prop=>new KeyValuePair<string,List<string>> 
								   (
								   	prop.Name,
									jo.SelectTokens(regex.Replace(prop.Path, x.ToString(), 1)).Select(c=>c.Value<string>()).ToList())));
							
    // Flatten the collection and Create DataRows
	foreach(var data in dataCollection)
	{
		for(var i=0;i<data.Select(x=>x.Value).Max(x=>x.Count);i++)
		{
			var innerList = new List<object>();
			foreach(var prop in config.Property)
			{
				var currentData = data.Where(x=>x.Key == prop.Name).SelectMany(x=>x.Value).ToList();
				innerList.Add(i>=currentData.Count ? currentData.Last():currentData[i]);
			}
			
			dataTable.Rows.Add(innerList.ToArray());
		}
	}
