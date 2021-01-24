	var settings = new JsonSerializerSettings
	{
		// Account for the custom DateTime format.
		DateFormatString = "dddd, MMMM d, yyyy @ h:mm:ss tt",
		// Do not re-serialize null `DateTime?` properties.
		NullValueHandling = NullValueHandling.Ignore,
		// Convert named c# properties -- but not dictionary keys -- to camel case
		ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
	};
	
	var inputs = JsonConvert.DeserializeObject<Dictionary<string, Input>>(json, settings);
	var outputJson = JsonConvert.SerializeObject(inputs, Formatting.Indented, settings);
