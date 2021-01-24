    [JsonConverter(typeof(MyCustomConverter))]
    public class MyClass
    {
        public Guid MyGuid { get;set; }
    }
