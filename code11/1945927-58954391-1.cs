    [JsonConverter(typeof(MyResponseConverter))]
    public class MyResponse
    {
    	[JsonProperty(PropertyName = "starttime")]
    	public string StartTime { get; set; }
    	[JsonProperty(PropertyName = "endtime")]
    	public string EndTime { get; set; }
    
    	public Dictionary<string, object> VarData { get; set; }
    }
