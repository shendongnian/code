        //this is the List that you will use to produce the expected JSON format
        List<Dictionary<string, object>> values = new List<Dictionary<string, object>>();
		
        //setup a Dictionary for every property you want to include
		Dictionary<string, object> ids = new Dictionary<string, object>();
		ids.Add("Attribute", "Id");
		for(int i = 0; i < examples.Count; i++)
			ids.Add("Example_" + (i + 1).ToString(), examples[i].Id);
		
        //add the dictionary to the list to be included in the JSON
		values.Add(ids);
		
        //serialize
		string json = JsonConvert.SerializeObject(values);
