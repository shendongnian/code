csharp
    var s = "{ \"SomeData\": \"blahblah\", \"SubObject\": {\"SomeData\": \"blahblah}{{\"	} } sdfsdfsdf... and some more data";
	var obj1 = JsonConvert.DeserializeObject(s, new JsonSerializerSettings() {
		CheckAdditionalContent = false // this is the key here, otherwise you will get an exception
	});
	
	JsonSerializer serializer = new JsonSerializer();
	var obj2 = serializer.Deserialize(new JsonTextReader(new StringReader(s))); // no issues here either
