    class RowData
    {
    	[JsonProperty("id")]
    	public int Id { get; set; }
    	[JsonProperty("anyOtherFixedField")]
    	public string OtherField{ get; set; }
    	[JsonExtensionData]
    	public IDictionary<string, JToken> ExtraProperties {get; set;}
    }
