    [Test]
    public void DynamicDeserialization()
    {
    	var jsonResponse = JsonConvert.DeserializeObject<dynamic>("{\"message\":\"Hi\"}");
    	Console.WriteLine(jsonResponse.message); // Hi
    }
