    class Program
    {
        static void Main(string[] args)
        {
            var deserialise = JsonConvert.DeserializeObject<RITMRequestResponse>("{\"result\": {\"123\" : { \"number\" : \"123\" }}}");
            Console.WriteLine(deserialise);
            Console.ReadLine();
        }
    }
    public class RITMRequestResponse
    {
        [JsonProperty(PropertyName = "result")]
        public Dictionary<string, RITMDetails> RITMDetails { get; set; }
    }
    public class RITMDetails
    {
        public string Number { get; set; }
    }
