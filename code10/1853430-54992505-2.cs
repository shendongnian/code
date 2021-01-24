	public class apiResults
	{
	    public int results;
	    public countries countries;
	}
	
	public class apiResponse
	{
	    public apiResults api;
	}
	
	[DataContract]
	public class countries
	{
		[DataMember(Name="1")]
		public string Country1 {get; set;}
	}
