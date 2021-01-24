         var settings = new JsonSerializerSettings();
		settings.Formatting = Formatting.Indented;
		settings.ContractResolver = new DictionaryAsArrayResolver();
		
		// serialize
		string json = JsonConvert.SerializeObject(Dict, settings);
