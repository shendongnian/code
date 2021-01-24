    public class Data4
    {
        [JsonProperty("DR")]
    	[JsonConverter(typeof(SingleOrArrayConverter<DR2>))] // Change here
        public List<DR2> DR { get; set; }
    }
