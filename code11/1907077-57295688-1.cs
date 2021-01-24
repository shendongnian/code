    string json = File.ReadAllText(@"d:\temp\test.json");
    var genericObject = JsonConvert.DeserializeObject<Response>(json);
    
    string message = genericObject.Message;
    foreach (var errorElement in genericObject.Errors) // see note about var below
    {
      string errorField = errorElement.Key;
      string errorDescription = errorElement.Value.FirstOrDefault(); // see below
    }
