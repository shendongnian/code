    var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore,ContractResolver = new CamelCasePropertyNamesContractResolver() };
	dynamic json = JsonConvert.DeserializeObject<ExpandoObject>(JSON);
		
	// modify your structure here...
    json.AlertInstructions[0].TimeStamp = 1234;
	var jsonToBeReturned = JsonConvert.SerializeObject(new {
		AlertId = 42,
		AlertInstructions  = json.AlertInstructions
	}, Formatting.Indented, settings);
