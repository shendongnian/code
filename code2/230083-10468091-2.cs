    [Test]
    public void DynamicDeserialization()
    {
    	dynamic jsonResponse = JsonConvert.DeserializeObject("{\"message\":\"Hi\"}");
    	jsonResponse.Works = true;
    	Console.WriteLine(jsonResponse.message); // Hi
    	Console.WriteLine(jsonResponse.Works); // True
    	Console.WriteLine(JsonConvert.SerializeObject(jsonResponse)); // {"message":"Hi","Works":true}
    	Assert.That(jsonResponse, Is.InstanceOf<dynamic>());
    	Assert.That(jsonResponse, Is.TypeOf<JObject>());
    }
