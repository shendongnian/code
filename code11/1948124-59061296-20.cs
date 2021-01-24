    [JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumMemberConverter))]  // This custom converter was placed in a system namespace.
	public enum Example 
	{
	  Trick,
	  Treat,
	  [EnumMember(Value = "Trick-Or-Treat")]
	   TrickOrTreat,
	}
