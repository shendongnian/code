    using Newtonsoft.Json;
        
    private T DeepCopy<T>(object input) where T : class
    {
        var copy = JsonConvert.SerializeObject((T)input); // serialise to string json object
        var output = JsonConvert.DeserializeObject<T>(copy); // deserialise back to poco
        return output;
    }
