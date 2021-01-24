cs
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var generator = new JsonSchemaGenerator();
            JsonSchema schema = generator.Generate(typeof(Person));
        }
    }
    public class Person
    {
        [JsonProperty]
        private string SecretName;
        public string PublicName { get; set; }
    }
The resulting schema has both `SecretName` and `PublicName`.
An alternative could also be to write a custom `IContractResolver` as shown [here][1].
Note that I did this by looking at the schema generation code for the obsolete methods in JSON.net, but I assume it will work similarly for the separate package. As far as I know, the source code for that is not public.
  [1]: https://www.newtonsoft.com/json/help/html/ContractResolver.htm
