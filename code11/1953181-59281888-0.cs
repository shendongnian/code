    public class ClassA
    {
      [JsonProperty("name")]
      public string Name { get; set; }
    
      [JsonProperty("objects")]
      public ClassB[] Objects { get; set; }
    }
