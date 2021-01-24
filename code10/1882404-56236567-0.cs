    public class MyClass
    {
        [JsonIgnore]
        public Guid MyGuid { get;set; }
        [JsonProperty("MyGuid")]
        public string DisplayGuid => MyGuid.ToString("N");
    }
