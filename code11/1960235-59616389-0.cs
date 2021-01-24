    var person = new Person()
		{
			Name = "John",
			Colors = new List<string>() {"Red", "Blue","Green"}
		};
		
		var rawJson = Newtonsoft.Json.JsonConvert.SerializeObject(person, Formatting.Indented);		
		var newJson = Newtonsoft.Json.JsonConvert.SerializeObject(person, Formatting.None);
		
		var settings =  new Newtonsoft.Json.JsonSerializerSettings();
		settings.Formatting = (Formatting)(newJson.Length <= rawJson.Length ? 1 : 0);		
		
		var finalJson = JsonConvert.SerializeObject(person, settings);
