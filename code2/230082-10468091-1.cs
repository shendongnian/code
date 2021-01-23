    [Test]
    public void DynamicDeserialization()
    {
    	dynamic jsonResponse = JsonConvert.DeserializeObject("{\"message\":\"Hi\"}");
    	Console.WriteLine(jsonResponse.message); // Hi
    }
