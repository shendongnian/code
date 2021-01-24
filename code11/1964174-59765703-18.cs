    public class Dto
    {
        [DtoDefinition(0)]
        public DateTime CurrentDate{get;set;}
        [DtoDefinition(1)]
        public string ID{get;set;}
        [DtoDefinition(2)]
        public string Url{get;set;}
    	[DtoDefinition(11,true,typeof(Response))]
    	public Response Json1{get;set;}
    }
    
    public class Response
    {
    	[JsonProperty("Response Size")]
    	public string ResponseSize{get;set;}
    	
    	[JsonProperty("Request Size")]
    	public string RequestSize{get;set;}
    	
    	[JsonProperty("Client Time (in ms)")]
    	public int ClientTime{get;set;}
    }
