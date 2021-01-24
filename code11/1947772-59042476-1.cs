    var instance = new RootObject { ID = 2, DisplayName = "John Doe" };
    var json = JsonConvert.SerializeObject(instance);
    var settings = new JsonSerializerSettings
    {
      ContractResolver = ShouldDeserializeContractResolver.Instance
    };
    Console.WriteLine(json);
    
    var deserializedInstance = JsonConvert.DeserializeObject<RootObject>(json, settings);
    Console.WriteLine($"Deserialized => Id={deserializedInstance.ID}, Name={deserializedInstance.DisplayName} ");
