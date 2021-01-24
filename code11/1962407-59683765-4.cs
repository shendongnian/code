    public class Rootobject
    {
        // public Los los { get; set; }
        // I don't think you need this converter unless you have special logic   
    	[JsonConverter(typeof(DictionaryToJsonObjectConverter))]
        public Dictionary<DateTime, List<Item>> los { get; set; }
        public int Id { get; set; }
    }
