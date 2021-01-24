	private IDictionary<string, object> _customDimensions;
	[JsonExtensionData(WriteData = false)]
	public IDictionary<string, object> ExtensionData
	{
		get { return _customDimensions; }
		set { _customDimensions = value; }
	}
	
	[JsonProperty("customDimensions")]
	public IDictionary<string, object> CustomDimensions
	{
		get { return _customDimensions; }
		set { _customDimensions = value; }
	}
	
