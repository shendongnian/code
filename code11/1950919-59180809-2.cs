    public interface IData{}
	public class Data4Partial:IData
	{
		[JsonProperty("DR")]
		public Dictionary<string,Dictionary<string,Dictionary<string,string>>> Data{get;set;}
	}
	public class DR2Full:IData
    {
        [JsonProperty("O")]
        public List<object> O { get; set; } 
        [JsonProperty("OC")]
        public List<string> OC { get; set; }
    }
    public class Data4Full:IData
    {
        [JsonProperty("DR")]
        public List<DR2Full> DR { get; set; }
    }
    public class Opt
    {
        [JsonProperty("data")]
        public IData data { get; set; }
    }
    public class SPFeed
    {
        [JsonProperty("opt")]
        public Opt opt { get; set; }
    }
