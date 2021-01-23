    [JsonObject(MemberSerialization.OptIn)]
    public partial class MyCustomItem
    {
    	[JsonProperty("Title")]
    	public string JsonTitle
    	{
    		get { return Title; }
    	}
    }
