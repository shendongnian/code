    [JsonObject(MemberSerialization=MemberSerialization.OptIn)]
    public class NamedIndividual1
    {
        [JsonProperty(Required = Required.Always)]
        public string FirstName { get; set; }
        [JsonProperty(Required = Required.Default)]
        public string MiddleInitial { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string LastName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name2 = "{'FirstName':'David', 'LastName':'Hoerster'}";
            var obj2 = JsonConvert.DeserializeObject<NamedIndividual>(name2);
            Console.WriteLine("{0} {1} {2}", obj2.FirstName, obj2.MiddleInitial, obj2.LastName);
        }
    }
