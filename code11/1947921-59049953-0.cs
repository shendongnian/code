    public class MyClass
    {
       [JsonProperty("name", Required = Required.Always)]
       public string Name { get; set; }
       [JsonProperty("email", Required = Required.Always)]
       public string Email { get; set; }
    }
